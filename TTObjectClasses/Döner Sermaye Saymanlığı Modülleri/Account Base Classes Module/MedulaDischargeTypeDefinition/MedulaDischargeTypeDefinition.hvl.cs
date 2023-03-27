
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaDischargeTypeDefinition")] 

    /// <summary>
    /// Medula Taburcu Tipi Eşleştirme
    /// </summary>
    public  partial class MedulaDischargeTypeDefinition : BaseMedulaDefinition
    {
        public class MedulaDischargeTypeDefinitionList : TTObjectCollection<MedulaDischargeTypeDefinition> { }
                    
        public class ChildMedulaDischargeTypeDefinitionCollection : TTObject.TTChildObjectCollection<MedulaDischargeTypeDefinition>
        {
            public ChildMedulaDischargeTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaDischargeTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedulaDisTypeDefQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string taburcuKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TABURCUKODU"].AllPropertyDefs["TABURCUKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string taburcuKoduAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUKODUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TABURCUKODU"].AllPropertyDefs["TABURCUKODUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DischargeTypeEnum? XXXXXXDischargeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXDISCHARGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULADISCHARGETYPEDEFINITION"].AllPropertyDefs["XXXXXXDISCHARGETYPE"].DataType;
                    return (DischargeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCIKISSEKLI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCIKISSEKLI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedulaDisTypeDefQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaDisTypeDefQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaDisTypeDefQuery_Class() : base() { }
        }

        public static BindingList<MedulaDischargeTypeDefinition> GetBySKRSCikisSekli(TTObjectContext objectContext, Guid SKRSCIKISSEKLI, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULADISCHARGETYPEDEFINITION"].QueryDefs["GetBySKRSCikisSekli"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSCIKISSEKLI", SKRSCIKISSEKLI);

            return ((ITTQuery)objectContext).QueryObjects<MedulaDischargeTypeDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<MedulaDischargeTypeDefinition> GetByMedulaDischargeCode(TTObjectContext objectContext, Guid MEDULADISCHARGECODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULADISCHARGETYPEDEFINITION"].QueryDefs["GetByMedulaDischargeCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MEDULADISCHARGECODE", MEDULADISCHARGECODE);

            return ((ITTQuery)objectContext).QueryObjects<MedulaDischargeTypeDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<MedulaDischargeTypeDefinition> GetByXXXXXXDischargeType(TTObjectContext objectContext, DischargeTypeEnum XXXXXXDISCHARGETYPE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULADISCHARGETYPEDEFINITION"].QueryDefs["GetByXXXXXXDischargeType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("XXXXXXDISCHARGETYPE", (int)XXXXXXDISCHARGETYPE);

            return ((ITTQuery)objectContext).QueryObjects<MedulaDischargeTypeDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<MedulaDischargeTypeDefinition.GetMedulaDisTypeDefQuery_Class> GetMedulaDisTypeDefQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULADISCHARGETYPEDEFINITION"].QueryDefs["GetMedulaDisTypeDefQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaDischargeTypeDefinition.GetMedulaDisTypeDefQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaDischargeTypeDefinition.GetMedulaDisTypeDefQuery_Class> GetMedulaDisTypeDefQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULADISCHARGETYPEDEFINITION"].QueryDefs["GetMedulaDisTypeDefQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaDischargeTypeDefinition.GetMedulaDisTypeDefQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// XXXXXX Taburcu Tipi
    /// </summary>
        public DischargeTypeEnum? XXXXXXDischargeType
        {
            get { return (DischargeTypeEnum?)(int?)this["XXXXXXDISCHARGETYPE"]; }
            set { this["XXXXXXDISCHARGETYPE"] = value; }
        }

        public SKRSCikisSekli SKRSCikisSekli
        {
            get { return (SKRSCikisSekli)((ITTObject)this).GetParent("SKRSCIKISSEKLI"); }
            set { this["SKRSCIKISSEKLI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TaburcuKodu MedulaDischargeCode
        {
            get { return (TaburcuKodu)((ITTObject)this).GetParent("MEDULADISCHARGECODE"); }
            set { this["MEDULADISCHARGECODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaDischargeTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaDischargeTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaDischargeTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaDischargeTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaDischargeTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULADISCHARGETYPEDEFINITION", dataRow) { }
        protected MedulaDischargeTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULADISCHARGETYPEDEFINITION", dataRow, isImported) { }
        public MedulaDischargeTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaDischargeTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaDischargeTypeDefinition() : base() { }

    }
}