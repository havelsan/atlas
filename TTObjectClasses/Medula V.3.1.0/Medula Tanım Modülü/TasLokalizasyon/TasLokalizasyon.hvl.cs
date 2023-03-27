
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TasLokalizasyon")] 

    public  partial class TasLokalizasyon : BaseMedulaDefinition
    {
        public class TasLokalizasyonList : TTObjectCollection<TasLokalizasyon> { }
                    
        public class ChildTasLokalizasyonCollection : TTObject.TTChildObjectCollection<TasLokalizasyon>
        {
            public ChildTasLokalizasyonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTasLokalizasyonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTasLokalizasyonDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? tasLokalizasyonKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TASLOKALIZASYONKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TASLOKALIZASYON"].AllPropertyDefs["TASLOKALIZASYONKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string tasLokalizasyonAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TASLOKALIZASYONADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TASLOKALIZASYON"].AllPropertyDefs["TASLOKALIZASYONADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTasLokalizasyonDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTasLokalizasyonDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTasLokalizasyonDefinitionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTasLokalizasyonQuery_Class : TTReportNqlObject 
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

            public string tasLokalizasyonAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TASLOKALIZASYONADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TASLOKALIZASYON"].AllPropertyDefs["TASLOKALIZASYONADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string tasLokalizasyonAdi_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TASLOKALIZASYONADI_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TASLOKALIZASYON"].AllPropertyDefs["TASLOKALIZASYONADI_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? tasLokalizasyonKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TASLOKALIZASYONKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TASLOKALIZASYON"].AllPropertyDefs["TASLOKALIZASYONKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetTasLokalizasyonQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTasLokalizasyonQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTasLokalizasyonQuery_Class() : base() { }
        }

        public static BindingList<TasLokalizasyon.GetTasLokalizasyonDefinitionQuery_Class> GetTasLokalizasyonDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TASLOKALIZASYON"].QueryDefs["GetTasLokalizasyonDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TasLokalizasyon.GetTasLokalizasyonDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TasLokalizasyon.GetTasLokalizasyonDefinitionQuery_Class> GetTasLokalizasyonDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TASLOKALIZASYON"].QueryDefs["GetTasLokalizasyonDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TasLokalizasyon.GetTasLokalizasyonDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TasLokalizasyon.GetTasLokalizasyonQuery_Class> GetTasLokalizasyonQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TASLOKALIZASYON"].QueryDefs["GetTasLokalizasyonQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TasLokalizasyon.GetTasLokalizasyonQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<TasLokalizasyon.GetTasLokalizasyonQuery_Class> GetTasLokalizasyonQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TASLOKALIZASYON"].QueryDefs["GetTasLokalizasyonQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TasLokalizasyon.GetTasLokalizasyonQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public string tasLokalizasyonAdi
        {
            get { return (string)this["TASLOKALIZASYONADI"]; }
            set { this["TASLOKALIZASYONADI"] = value; }
        }

        public string tasLokalizasyonAdi_Shadow
        {
            get { return (string)this["TASLOKALIZASYONADI_SHADOW"]; }
            set { this["TASLOKALIZASYONADI_SHADOW"] = value; }
        }

        public int? tasLokalizasyonKodu
        {
            get { return (int?)this["TASLOKALIZASYONKODU"]; }
            set { this["TASLOKALIZASYONKODU"] = value; }
        }

        protected TasLokalizasyon(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TasLokalizasyon(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TasLokalizasyon(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TasLokalizasyon(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TasLokalizasyon(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TASLOKALIZASYON", dataRow) { }
        protected TasLokalizasyon(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TASLOKALIZASYON", dataRow, isImported) { }
        public TasLokalizasyon(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TasLokalizasyon(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TasLokalizasyon() : base() { }

    }
}