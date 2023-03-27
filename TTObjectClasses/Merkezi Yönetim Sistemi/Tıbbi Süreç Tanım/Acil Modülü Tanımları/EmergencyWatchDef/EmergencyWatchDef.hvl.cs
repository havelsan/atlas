
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyWatchDef")] 

    /// <summary>
    /// Nöbetçi Personel
    /// </summary>
    public  partial class EmergencyWatchDef : TTDefinitionSet
    {
        public class EmergencyWatchDefList : TTObjectCollection<EmergencyWatchDef> { }
                    
        public class ChildEmergencyWatchDefCollection : TTObject.TTChildObjectCollection<EmergencyWatchDef>
        {
            public ChildEmergencyWatchDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyWatchDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEmergencyWatchPersonelList_Class : TTReportNqlObject 
        {
            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHDEF"].AllPropertyDefs["TARIH"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHPERSONELDEF"].AllPropertyDefs["BASLANGICTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BitisTarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BITISTARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHPERSONELDEF"].AllPropertyDefs["BITISTARIH"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Bildirildi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BILDIRILDI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHPERSONELDEF"].AllPropertyDefs["BILDIRILDI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTypeEnum? Gorevi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GOREVI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? MainSpeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCESPECIALITYGRID"].AllPropertyDefs["MAINSPECIALITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Brans
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Icapci
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICAPCI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHPERSONELDEF"].AllPropertyDefs["ICAPCI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetEmergencyWatchPersonelList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyWatchPersonelList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyWatchPersonelList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyWatchDefs_Class : TTReportNqlObject 
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

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHDEF"].AllPropertyDefs["TARIH"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetEmergencyWatchDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyWatchDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyWatchDefs_Class() : base() { }
        }

        public static BindingList<EmergencyWatchDef.GetEmergencyWatchPersonelList_Class> GetEmergencyWatchPersonelList(DateTime TARIHI, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHDEF"].QueryDefs["GetEmergencyWatchPersonelList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TARIHI", TARIHI);

            return TTReportNqlObject.QueryObjects<EmergencyWatchDef.GetEmergencyWatchPersonelList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyWatchDef.GetEmergencyWatchPersonelList_Class> GetEmergencyWatchPersonelList(TTObjectContext objectContext, DateTime TARIHI, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHDEF"].QueryDefs["GetEmergencyWatchPersonelList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TARIHI", TARIHI);

            return TTReportNqlObject.QueryObjects<EmergencyWatchDef.GetEmergencyWatchPersonelList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EmergencyWatchDef.GetEmergencyWatchDefs_Class> GetEmergencyWatchDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHDEF"].QueryDefs["GetEmergencyWatchDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EmergencyWatchDef.GetEmergencyWatchDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EmergencyWatchDef.GetEmergencyWatchDefs_Class> GetEmergencyWatchDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYWATCHDEF"].QueryDefs["GetEmergencyWatchDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EmergencyWatchDef.GetEmergencyWatchDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Tarih
        {
            get { return (DateTime?)this["TARIH"]; }
            set { this["TARIH"] = value; }
        }

        virtual protected void CreateEmergencyWatchPersonelDefsCollection()
        {
            _EmergencyWatchPersonelDefs = new EmergencyWatchPersonelDef.ChildEmergencyWatchPersonelDefCollection(this, new Guid("ee158bd7-373b-4d16-8695-d566a4c131bf"));
            ((ITTChildObjectCollection)_EmergencyWatchPersonelDefs).GetChildren();
        }

        protected EmergencyWatchPersonelDef.ChildEmergencyWatchPersonelDefCollection _EmergencyWatchPersonelDefs = null;
        public EmergencyWatchPersonelDef.ChildEmergencyWatchPersonelDefCollection EmergencyWatchPersonelDefs
        {
            get
            {
                if (_EmergencyWatchPersonelDefs == null)
                    CreateEmergencyWatchPersonelDefsCollection();
                return _EmergencyWatchPersonelDefs;
            }
        }

        protected EmergencyWatchDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyWatchDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyWatchDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyWatchDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyWatchDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYWATCHDEF", dataRow) { }
        protected EmergencyWatchDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYWATCHDEF", dataRow, isImported) { }
        public EmergencyWatchDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyWatchDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyWatchDef() : base() { }

    }
}