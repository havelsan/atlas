
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSRadyolojikTetkikIstemPeriyoduListesi")] 

    /// <summary>
    /// c073f7bf-791f-40cf-8fd4-e7ac5e1683de
    /// </summary>
    public  partial class SKRSRadyolojikTetkikIstemPeriyoduListesi : BaseSKRSDefinition
    {
        public class SKRSRadyolojikTetkikIstemPeriyoduListesiList : TTObjectCollection<SKRSRadyolojikTetkikIstemPeriyoduListesi> { }
                    
        public class ChildSKRSRadyolojikTetkikIstemPeriyoduListesiCollection : TTObject.TTChildObjectCollection<SKRSRadyolojikTetkikIstemPeriyoduListesi>
        {
            public ChildSKRSRadyolojikTetkikIstemPeriyoduListesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSRadyolojikTetkikIstemPeriyoduListesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSRadyolojikTetkikIstemPeriyoduListesi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SUTKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["SUTKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ISTEMSURESI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEMSURESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["ISTEMSURESI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ACIKLAMA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["ACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLENMETARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSRadyolojikTetkikIstemPeriyoduListesi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSRadyolojikTetkikIstemPeriyoduListesi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSRadyolojikTetkikIstemPeriyoduListesi_Class() : base() { }
        }

        public static BindingList<SKRSRadyolojikTetkikIstemPeriyoduListesi.GetSKRSRadyolojikTetkikIstemPeriyoduListesi_Class> GetSKRSRadyolojikTetkikIstemPeriyoduListesi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].QueryDefs["GetSKRSRadyolojikTetkikIstemPeriyoduListesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSRadyolojikTetkikIstemPeriyoduListesi.GetSKRSRadyolojikTetkikIstemPeriyoduListesi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSRadyolojikTetkikIstemPeriyoduListesi.GetSKRSRadyolojikTetkikIstemPeriyoduListesi_Class> GetSKRSRadyolojikTetkikIstemPeriyoduListesi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI"].QueryDefs["GetSKRSRadyolojikTetkikIstemPeriyoduListesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSRadyolojikTetkikIstemPeriyoduListesi.GetSKRSRadyolojikTetkikIstemPeriyoduListesi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public string SUTKODU
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

        public int? ISTEMSURESI
        {
            get { return (int?)this["ISTEMSURESI"]; }
            set { this["ISTEMSURESI"] = value; }
        }

        public string ACIKLAMA
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

        public DateTime? OLUSTURULMATARIHI1
        {
            get { return (DateTime?)this["OLUSTURULMATARIHI1"]; }
            set { this["OLUSTURULMATARIHI1"] = value; }
        }

        public DateTime? GUNCELLENMETARIHI1
        {
            get { return (DateTime?)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        protected SKRSRadyolojikTetkikIstemPeriyoduListesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSRadyolojikTetkikIstemPeriyoduListesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSRadyolojikTetkikIstemPeriyoduListesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSRadyolojikTetkikIstemPeriyoduListesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSRadyolojikTetkikIstemPeriyoduListesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI", dataRow) { }
        protected SKRSRadyolojikTetkikIstemPeriyoduListesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSRADYOLOJIKTETKIKISTEMPERIYODULISTESI", dataRow, isImported) { }
        public SKRSRadyolojikTetkikIstemPeriyoduListesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSRadyolojikTetkikIstemPeriyoduListesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSRadyolojikTetkikIstemPeriyoduListesi() : base() { }

    }
}