
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResRoom")] 

    /// <summary>
    /// Oda
    /// </summary>
    public  partial class ResRoom : ResSection
    {
        public class ResRoomList : TTObjectCollection<ResRoom> { }
                    
        public class ChildResRoomCollection : TTObject.TTChildObjectCollection<ResRoom>
        {
            public ChildResRoomCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResRoomCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResRoom_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? RoomGroup
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOMGROUP"]);
                }
            }

            public OLAP_ResRoom_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResRoom_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResRoom_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRoomDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Roomgroupname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRoomDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRoomDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRoomDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_ODA_Class : TTReportNqlObject 
        {
            public Guid? Oda_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Oda_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODA_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Birim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BIRIM_KODU"]);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_ODA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_ODA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_ODA_Class() : base() { }
        }

        public static BindingList<ResRoom.OLAP_ResRoom_Class> OLAP_ResRoom(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].QueryDefs["OLAP_ResRoom"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoom.OLAP_ResRoom_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResRoom.OLAP_ResRoom_Class> OLAP_ResRoom(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].QueryDefs["OLAP_ResRoom"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoom.OLAP_ResRoom_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResRoom.GetRoomDefinition_Class> GetRoomDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].QueryDefs["GetRoomDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoom.GetRoomDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResRoom.GetRoomDefinition_Class> GetRoomDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].QueryDefs["GetRoomDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoom.GetRoomDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResRoom.VEM_ODA_Class> VEM_ODA(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].QueryDefs["VEM_ODA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoom.VEM_ODA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResRoom.VEM_ODA_Class> VEM_ODA(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].QueryDefs["VEM_ODA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoom.VEM_ODA_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// OdaGroup
    /// </summary>
        public ResRoomGroup RoomGroup
        {
            get { return (ResRoomGroup)((ITTObject)this).GetParent("ROOMGROUP"); }
            set { this["ROOMGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBedsCollection()
        {
            _Beds = new ResBed.ChildResBedCollection(this, new Guid("cb64e2c1-6184-4ebc-bd0a-d8b0d5fa6c55"));
            ((ITTChildObjectCollection)_Beds).GetChildren();
        }

        protected ResBed.ChildResBedCollection _Beds = null;
    /// <summary>
    /// Child collection for Oda
    /// </summary>
        public ResBed.ChildResBedCollection Beds
        {
            get
            {
                if (_Beds == null)
                    CreateBedsCollection();
                return _Beds;
            }
        }

        protected ResRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResRoom(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResRoom(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResRoom(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESROOM", dataRow) { }
        protected ResRoom(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESROOM", dataRow, isImported) { }
        public ResRoom(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResRoom(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResRoom() : base() { }

    }
}