
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BeneficiaryDefinition")] 

    /// <summary>
    /// Haksahipliği Tanımlama
    /// </summary>
    public  partial class BeneficiaryDefinition : TTDefinitionSet
    {
        public class BeneficiaryDefinitionList : TTObjectCollection<BeneficiaryDefinition> { }
                    
        public class ChildBeneficiaryDefinitionCollection : TTObject.TTChildObjectCollection<BeneficiaryDefinition>
        {
            public ChildBeneficiaryDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBeneficiaryDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBeneficiaryDefinitonNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BENEFICIARYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BENEFICIARYDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FormerCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORMERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BENEFICIARYDEFINITION"].AllPropertyDefs["FORMERCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBeneficiaryDefinitonNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBeneficiaryDefinitonNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBeneficiaryDefinitonNQL_Class() : base() { }
        }

        public static BindingList<BeneficiaryDefinition.GetBeneficiaryDefinitonNQL_Class> GetBeneficiaryDefinitonNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BENEFICIARYDEFINITION"].QueryDefs["GetBeneficiaryDefinitonNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BeneficiaryDefinition.GetBeneficiaryDefinitonNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BeneficiaryDefinition.GetBeneficiaryDefinitonNQL_Class> GetBeneficiaryDefinitonNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BENEFICIARYDEFINITION"].QueryDefs["GetBeneficiaryDefinitonNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BeneficiaryDefinition.GetBeneficiaryDefinitonNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BeneficiaryDefinition> GetBeneficiaryDefinitionByExternalCode(TTObjectContext objectContext, string EXTERNALCODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BENEFICIARYDEFINITION"].QueryDefs["GetBeneficiaryDefinitionByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<BeneficiaryDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Harici Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Önceki Kodu
    /// </summary>
        public string FormerCode
        {
            get { return (string)this["FORMERCODE"]; }
            set { this["FORMERCODE"] = value; }
        }

    /// <summary>
    /// Adı
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

        protected BeneficiaryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BeneficiaryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BeneficiaryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BeneficiaryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BeneficiaryDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BENEFICIARYDEFINITION", dataRow) { }
        protected BeneficiaryDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BENEFICIARYDEFINITION", dataRow, isImported) { }
        public BeneficiaryDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BeneficiaryDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BeneficiaryDefinition() : base() { }

    }
}