
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurPlusNeedDefinition")] 

    /// <summary>
    /// İhtiyaç fazlası mevcut inceleme modülünün ana sınıfıdır
    /// </summary>
    public  partial class SurPlusNeedDefinition : TTObject
    {
        public class SurPlusNeedDefinitionList : TTObjectCollection<SurPlusNeedDefinition> { }
                    
        public class ChildSurPlusNeedDefinitionCollection : TTObject.TTChildObjectCollection<SurPlusNeedDefinition>
        {
            public ChildSurPlusNeedDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurPlusNeedDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SurPlusNeedDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Accountancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURPLUSNEEDDEFINITION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public SurPlusNeedStatus? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURPLUSNEEDDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (SurPlusNeedStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURPLUSNEEDDEFINITION"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public SurPlusNeedDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SurPlusNeedDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SurPlusNeedDefFormNQL_Class() : base() { }
        }

        public static BindingList<SurPlusNeedDefinition.SurPlusNeedDefFormNQL_Class> SurPlusNeedDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURPLUSNEEDDEFINITION"].QueryDefs["SurPlusNeedDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurPlusNeedDefinition.SurPlusNeedDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurPlusNeedDefinition.SurPlusNeedDefFormNQL_Class> SurPlusNeedDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURPLUSNEEDDEFINITION"].QueryDefs["SurPlusNeedDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurPlusNeedDefinition.SurPlusNeedDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public SurPlusNeedStatus? Status
        {
            get { return (SurPlusNeedStatus?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Miadı
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SurPlusNeedDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurPlusNeedDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurPlusNeedDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurPlusNeedDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurPlusNeedDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURPLUSNEEDDEFINITION", dataRow) { }
        protected SurPlusNeedDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURPLUSNEEDDEFINITION", dataRow, isImported) { }
        public SurPlusNeedDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurPlusNeedDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurPlusNeedDefinition() : base() { }

    }
}