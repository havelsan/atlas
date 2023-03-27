
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSUlkeKodlari")] 

    /// <summary>
    /// d650777a-3d4d-a259-e040-7c0a01167a83
    /// </summary>
    public  partial class SKRSUlkeKodlari : BaseSKRSDefinition
    {
        public class SKRSUlkeKodlariList : TTObjectCollection<SKRSUlkeKodlari> { }
                    
        public class ChildSKRSUlkeKodlariCollection : TTObject.TTChildObjectCollection<SKRSUlkeKodlari>
        {
            public ChildSKRSUlkeKodlariCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSUlkeKodlariCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSUlkeKodlari_Class : TTReportNqlObject 
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

            public bool? Default
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFAULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["DEFAULT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AKTIF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKTIF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["AKTIF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLENMETARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PASIFEALINMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASIFEALINMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLEMETARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLEMETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MernisKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MERNISKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["MERNISKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OlusturulmaTarihi1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLENMETARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Adi_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].AllPropertyDefs["ADI_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSUlkeKodlari_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSUlkeKodlari_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSUlkeKodlari_Class() : base() { }
        }

        public static BindingList<SKRSUlkeKodlari.GetSKRSUlkeKodlari_Class> GetSKRSUlkeKodlari(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].QueryDefs["GetSKRSUlkeKodlari"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSUlkeKodlari.GetSKRSUlkeKodlari_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSUlkeKodlari.GetSKRSUlkeKodlari_Class> GetSKRSUlkeKodlari(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].QueryDefs["GetSKRSUlkeKodlari"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSUlkeKodlari.GetSKRSUlkeKodlari_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSUlkeKodlari> GetByMernisKodu(TTObjectContext objectContext, string MERNISKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].QueryDefs["GetByMernisKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MERNISKODU", MERNISKODU);

            return ((ITTQuery)objectContext).QueryObjects<SKRSUlkeKodlari>(queryDef, paramList);
        }

        public static BindingList<SKRSUlkeKodlari> GetBySKRSKodu(TTObjectContext objectContext, string SKRSKodu)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSULKEKODLARI"].QueryDefs["GetBySKRSKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSKODU", SKRSKodu);

            return ((ITTQuery)objectContext).QueryObjects<SKRSUlkeKodlari>(queryDef, paramList);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Adi
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Kodu
        {
            get { return (string)this["KODU"]; }
            set { this["KODU"] = value; }
        }

    /// <summary>
    /// Mernis Kodu
    /// </summary>
        public string MernisKodu
        {
            get { return (string)this["MERNISKODU"]; }
            set { this["MERNISKODU"] = value; }
        }

    /// <summary>
    /// Oluşturulma Tarihi
    /// </summary>
        public string OlusturulmaTarihi1
        {
            get { return (string)this["OLUSTURULMATARIHI1"]; }
            set { this["OLUSTURULMATARIHI1"] = value; }
        }

        public DateTime? GUNCELLENMETARIHI1
        {
            get { return (DateTime?)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        public string Adi_Shadow
        {
            get { return (string)this["ADI_SHADOW"]; }
        }

        protected SKRSUlkeKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSUlkeKodlari(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSUlkeKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSUlkeKodlari(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSUlkeKodlari(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSULKEKODLARI", dataRow) { }
        protected SKRSUlkeKodlari(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSULKEKODLARI", dataRow, isImported) { }
        public SKRSUlkeKodlari(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSUlkeKodlari(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSUlkeKodlari() : base() { }

    }
}