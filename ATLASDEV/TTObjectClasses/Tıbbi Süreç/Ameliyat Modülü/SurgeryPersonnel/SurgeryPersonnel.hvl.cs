
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryPersonnel")] 

    /// <summary>
    /// Ameliyat Ekibi
    /// </summary>
    public  partial class SurgeryPersonnel : TTObject
    {
        public class SurgeryPersonnelList : TTObjectCollection<SurgeryPersonnel> { }
                    
        public class ChildSurgeryPersonnelCollection : TTObject.TTChildObjectCollection<SurgeryPersonnel>
        {
            public ChildSurgeryPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetSurgeryPersonnel_Class : TTReportNqlObject 
        {
            public Guid? Personnel
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PERSONNEL"]);
                }
            }

            public SurgeryRoleEnum? Role
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].AllPropertyDefs["ROLE"].DataType;
                    return (SurgeryRoleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetSurgeryPersonnel_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgeryPersonnel_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgeryPersonnel_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllPersonelBySurgery_Class : TTReportNqlObject 
        {
            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Personnelname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONNELNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SurgeryRoleEnum? Role
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].AllPropertyDefs["ROLE"].DataType;
                    return (SurgeryRoleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetAllPersonelBySurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllPersonelBySurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllPersonelBySurgery_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_AMELIYAT_EKIP_Class : TTReportNqlObject 
        {
            public Guid? Ameliyat_ekip_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["AMELIYAT_EKIP_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Ameliyat_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["AMELIYAT_KODU"]);
                }
            }

            public Guid? Ameliyat_islem_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["AMELIYAT_ISLEM_KODU"]);
                }
            }

            public Object Ekip_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKIP_NUMARASI"]);
                }
            }

            public Guid? Personel_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PERSONEL_KODU"]);
                }
            }

            public Object Personel_gorev
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PERSONEL_GOREV"]);
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

            public VEM_AMELIYAT_EKIP_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_AMELIYAT_EKIP_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_AMELIYAT_EKIP_Class() : base() { }
        }

        public static BindingList<SurgeryPersonnel.OLAP_GetSurgeryPersonnel_Class> OLAP_GetSurgeryPersonnel(string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].QueryDefs["OLAP_GetSurgeryPersonnel"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SurgeryPersonnel.OLAP_GetSurgeryPersonnel_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryPersonnel.OLAP_GetSurgeryPersonnel_Class> OLAP_GetSurgeryPersonnel(TTObjectContext objectContext, string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].QueryDefs["OLAP_GetSurgeryPersonnel"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SurgeryPersonnel.OLAP_GetSurgeryPersonnel_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryPersonnel> GetAllPersonnelBySurgery(TTObjectContext objectContext, Guid SURGERY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].QueryDefs["GetAllPersonnelBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return ((ITTQuery)objectContext).QueryObjects<SurgeryPersonnel>(queryDef, paramList);
        }

        public static BindingList<SurgeryPersonnel.GetAllPersonelBySurgery_Class> GetAllPersonelBySurgery(Guid SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].QueryDefs["GetAllPersonelBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SurgeryPersonnel.GetAllPersonelBySurgery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryPersonnel.GetAllPersonelBySurgery_Class> GetAllPersonelBySurgery(TTObjectContext objectContext, Guid SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].QueryDefs["GetAllPersonelBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<SurgeryPersonnel.GetAllPersonelBySurgery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SurgeryPersonnel.VEM_AMELIYAT_EKIP_Class> VEM_AMELIYAT_EKIP(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].QueryDefs["VEM_AMELIYAT_EKIP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryPersonnel.VEM_AMELIYAT_EKIP_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SurgeryPersonnel.VEM_AMELIYAT_EKIP_Class> VEM_AMELIYAT_EKIP(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYPERSONNEL"].QueryDefs["VEM_AMELIYAT_EKIP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryPersonnel.VEM_AMELIYAT_EKIP_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public SurgeryRoleEnum? Role
        {
            get { return (SurgeryRoleEnum?)(int?)this["ROLE"]; }
            set { this["ROLE"] = value; }
        }

    /// <summary>
    /// Ameliyat Ekibi Sekmesi
    /// </summary>
        public Surgery Surgery
        {
            get { return (Surgery)((ITTObject)this).GetParent("SURGERY"); }
            set { this["SURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ameliyat Ekibi
    /// </summary>
        public ResUser Personnel
        {
            get { return (ResUser)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SurgeryPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYPERSONNEL", dataRow) { }
        protected SurgeryPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYPERSONNEL", dataRow, isImported) { }
        public SurgeryPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryPersonnel() : base() { }

    }
}