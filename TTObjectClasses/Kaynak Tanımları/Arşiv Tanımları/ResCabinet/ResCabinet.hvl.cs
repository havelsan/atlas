
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResCabinet")] 

    /// <summary>
    /// Arşiv dosyaları için dolap tanımları
    /// </summary>
    public  partial class ResCabinet : ResSection
    {
        public class ResCabinetList : TTObjectCollection<ResCabinet> { }
                    
        public class ChildResCabinetCollection : TTObject.TTChildObjectCollection<ResCabinet>
        {
            public ChildResCabinetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResCabinetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCabinetDefinitionListNql_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCABINET"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Roomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESARCHIVEROOM"].AllPropertyDefs["NAME"].DataType;
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

            public GetCabinetDefinitionListNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCabinetDefinitionListNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCabinetDefinitionListNql_Class() : base() { }
        }

        public static BindingList<ResCabinet> GetCabinetListDefinitionNql(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCABINET"].QueryDefs["GetCabinetListDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResCabinet>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResCabinet.GetCabinetDefinitionListNql_Class> GetCabinetDefinitionListNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCABINET"].QueryDefs["GetCabinetDefinitionListNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResCabinet.GetCabinetDefinitionListNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResCabinet.GetCabinetDefinitionListNql_Class> GetCabinetDefinitionListNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCABINET"].QueryDefs["GetCabinetDefinitionListNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResCabinet.GetCabinetDefinitionListNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Dolabın bulunduğu oda
    /// </summary>
        public ResArchiveRoom ResArchiveRoom
        {
            get { return (ResArchiveRoom)((ITTObject)this).GetParent("RESARCHIVEROOM"); }
            set { this["RESARCHIVEROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResShelvesCollection()
        {
            _ResShelves = new ResShelf.ChildResShelfCollection(this, new Guid("72281112-a780-49ba-a0f0-072d09033d5b"));
            ((ITTChildObjectCollection)_ResShelves).GetChildren();
        }

        protected ResShelf.ChildResShelfCollection _ResShelves = null;
        public ResShelf.ChildResShelfCollection ResShelves
        {
            get
            {
                if (_ResShelves == null)
                    CreateResShelvesCollection();
                return _ResShelves;
            }
        }

        protected ResCabinet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResCabinet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResCabinet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResCabinet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResCabinet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESCABINET", dataRow) { }
        protected ResCabinet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESCABINET", dataRow, isImported) { }
        public ResCabinet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResCabinet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResCabinet() : base() { }

    }
}