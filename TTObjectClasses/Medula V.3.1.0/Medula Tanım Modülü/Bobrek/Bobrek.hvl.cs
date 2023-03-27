
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Bobrek")] 

    public  partial class Bobrek : BaseMedulaDefinition
    {
        public class BobrekList : TTObjectCollection<Bobrek> { }
                    
        public class ChildBobrekCollection : TTObject.TTChildObjectCollection<Bobrek>
        {
            public ChildBobrekCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBobrekCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBobrekDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? bobrekKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOBREKKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BOBREK"].AllPropertyDefs["BOBREKKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string bobrekAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOBREKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BOBREK"].AllPropertyDefs["BOBREKADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBobrekDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBobrekDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBobrekDefinitionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBobrekQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string bobrekAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOBREKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BOBREK"].AllPropertyDefs["BOBREKADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string bobrekAdi_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOBREKADI_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BOBREK"].AllPropertyDefs["BOBREKADI_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? bobrekKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOBREKKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BOBREK"].AllPropertyDefs["BOBREKKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetBobrekQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBobrekQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBobrekQuery_Class() : base() { }
        }

        public static BindingList<Bobrek.GetBobrekDefinitionQuery_Class> GetBobrekDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BOBREK"].QueryDefs["GetBobrekDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Bobrek.GetBobrekDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Bobrek.GetBobrekDefinitionQuery_Class> GetBobrekDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BOBREK"].QueryDefs["GetBobrekDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Bobrek.GetBobrekDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Bobrek.GetBobrekQuery_Class> GetBobrekQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BOBREK"].QueryDefs["GetBobrekQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Bobrek.GetBobrekQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Bobrek.GetBobrekQuery_Class> GetBobrekQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BOBREK"].QueryDefs["GetBobrekQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Bobrek.GetBobrekQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public string bobrekAdi
        {
            get { return (string)this["BOBREKADI"]; }
            set { this["BOBREKADI"] = value; }
        }

        public string bobrekAdi_Shadow
        {
            get { return (string)this["BOBREKADI_SHADOW"]; }
            set { this["BOBREKADI_SHADOW"] = value; }
        }

        public int? bobrekKodu
        {
            get { return (int?)this["BOBREKKODU"]; }
            set { this["BOBREKKODU"] = value; }
        }

        protected Bobrek(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Bobrek(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Bobrek(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Bobrek(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Bobrek(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BOBREK", dataRow) { }
        protected Bobrek(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BOBREK", dataRow, isImported) { }
        public Bobrek(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Bobrek(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Bobrek() : base() { }

    }
}