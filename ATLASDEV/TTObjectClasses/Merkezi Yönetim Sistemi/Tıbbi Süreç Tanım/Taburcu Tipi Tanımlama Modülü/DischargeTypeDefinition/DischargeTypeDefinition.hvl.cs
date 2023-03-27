
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DischargeTypeDefinition")] 

    public  partial class DischargeTypeDefinition : TerminologyManagerDef
    {
        public class DischargeTypeDefinitionList : TTObjectCollection<DischargeTypeDefinition> { }
                    
        public class ChildDischargeTypeDefinitionCollection : TTObject.TTChildObjectCollection<DischargeTypeDefinition>
        {
            public ChildDischargeTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDischargeTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDischargeTypeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? SKRSCikisSekli
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SKRSCIKISSEKLI"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISCHARGETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDischargeTypeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDischargeTypeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDischargeTypeDefinitionList_Class() : base() { }
        }

        public static BindingList<DischargeTypeDefinition> GetAll(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGETYPEDEFINITION"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DischargeTypeDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DischargeTypeDefinition.GetDischargeTypeDefinitionList_Class> GetDischargeTypeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGETYPEDEFINITION"].QueryDefs["GetDischargeTypeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DischargeTypeDefinition.GetDischargeTypeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DischargeTypeDefinition.GetDischargeTypeDefinitionList_Class> GetDischargeTypeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGETYPEDEFINITION"].QueryDefs["GetDischargeTypeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DischargeTypeDefinition.GetDischargeTypeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DischargeTypeDefinition> GetActives(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGETYPEDEFINITION"].QueryDefs["GetActives"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DischargeTypeDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DischargeTypeDefinition> GetDischargeTypeBySkrsCikisSekli(TTObjectContext objectContext, int SKRSKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGETYPEDEFINITION"].QueryDefs["GetDischargeTypeBySkrsCikisSekli"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSKODU", SKRSKODU);

            return ((ITTQuery)objectContext).QueryObjects<DischargeTypeDefinition>(queryDef, paramList);
        }

        public static BindingList<DischargeTypeDefinition> GetByObjectId(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGETYPEDEFINITION"].QueryDefs["GetByObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<DischargeTypeDefinition>(queryDef, paramList);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public SKRSCikisSekli SKRSCikisSekli
        {
            get { return (SKRSCikisSekli)((ITTObject)this).GetParent("SKRSCIKISSEKLI"); }
            set { this["SKRSCIKISSEKLI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DischargeTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DischargeTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DischargeTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DischargeTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DischargeTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISCHARGETYPEDEFINITION", dataRow) { }
        protected DischargeTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISCHARGETYPEDEFINITION", dataRow, isImported) { }
        public DischargeTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DischargeTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DischargeTypeDefinition() : base() { }

    }
}