
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryCategoryDefinition")] 

    /// <summary>
    /// Ameliyat Kategorisi
    /// </summary>
    public  partial class SurgeryCategoryDefinition : TerminologyManagerDef
    {
        public class SurgeryCategoryDefinitionList : TTObjectCollection<SurgeryCategoryDefinition> { }
                    
        public class ChildSurgeryCategoryDefinitionCollection : TTObject.TTChildObjectCollection<SurgeryCategoryDefinition>
        {
            public ChildSurgeryCategoryDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryCategoryDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSurgeryCategoryDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryCategoryDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryCategoryDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryCategoryDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_SurgeryCategoryDefiniton_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_SurgeryCategoryDefiniton_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SurgeryCategoryDefiniton_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SurgeryCategoryDefiniton_Class() : base() { }
        }

        public static BindingList<SurgeryCategoryDefinition.GetSurgeryCategoryDefinition_Class> GetSurgeryCategoryDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].QueryDefs["GetSurgeryCategoryDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryCategoryDefinition.GetSurgeryCategoryDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryCategoryDefinition.GetSurgeryCategoryDefinition_Class> GetSurgeryCategoryDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].QueryDefs["GetSurgeryCategoryDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryCategoryDefinition.GetSurgeryCategoryDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryCategoryDefinition.OLAP_SurgeryCategoryDefiniton_Class> OLAP_SurgeryCategoryDefiniton(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].QueryDefs["OLAP_SurgeryCategoryDefiniton"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryCategoryDefinition.OLAP_SurgeryCategoryDefiniton_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryCategoryDefinition.OLAP_SurgeryCategoryDefiniton_Class> OLAP_SurgeryCategoryDefiniton(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].QueryDefs["OLAP_SurgeryCategoryDefiniton"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryCategoryDefinition.OLAP_SurgeryCategoryDefiniton_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryCategoryDefinition> GetSurgeryProcedureCategoryByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYCATEGORYDEFINITION"].QueryDefs["GetSurgeryProcedureCategoryByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SurgeryCategoryDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// ID
    /// </summary>
        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected SurgeryCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryCategoryDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYCATEGORYDEFINITION", dataRow) { }
        protected SurgeryCategoryDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYCATEGORYDEFINITION", dataRow, isImported) { }
        public SurgeryCategoryDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryCategoryDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryCategoryDefinition() : base() { }

    }
}