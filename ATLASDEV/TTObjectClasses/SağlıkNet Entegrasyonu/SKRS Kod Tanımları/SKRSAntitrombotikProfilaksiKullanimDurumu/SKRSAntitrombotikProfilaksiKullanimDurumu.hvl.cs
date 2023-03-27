
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSAntitrombotikProfilaksiKullanimDurumu")] 

    /// <summary>
    /// f1b3a222-d139-40c4-9255-b2bec4d9c9b8
    /// </summary>
    public  partial class SKRSAntitrombotikProfilaksiKullanimDurumu : BaseSKRSDefinition
    {
        public class SKRSAntitrombotikProfilaksiKullanimDurumuList : TTObjectCollection<SKRSAntitrombotikProfilaksiKullanimDurumu> { }
                    
        public class ChildSKRSAntitrombotikProfilaksiKullanimDurumuCollection : TTObject.TTChildObjectCollection<SKRSAntitrombotikProfilaksiKullanimDurumu>
        {
            public ChildSKRSAntitrombotikProfilaksiKullanimDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSAntitrombotikProfilaksiKullanimDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSAntitrombotikProfilaksiKullanimDurumu_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string KODTIPIADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].AllPropertyDefs["KODTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSAntitrombotikProfilaksiKullanimDurumu_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSAntitrombotikProfilaksiKullanimDurumu_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSAntitrombotikProfilaksiKullanimDurumu_Class() : base() { }
        }

        public static BindingList<SKRSAntitrombotikProfilaksiKullanimDurumu.GetSKRSAntitrombotikProfilaksiKullanimDurumu_Class> GetSKRSAntitrombotikProfilaksiKullanimDurumu(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].QueryDefs["GetSKRSAntitrombotikProfilaksiKullanimDurumu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAntitrombotikProfilaksiKullanimDurumu.GetSKRSAntitrombotikProfilaksiKullanimDurumu_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSAntitrombotikProfilaksiKullanimDurumu.GetSKRSAntitrombotikProfilaksiKullanimDurumu_Class> GetSKRSAntitrombotikProfilaksiKullanimDurumu(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU"].QueryDefs["GetSKRSAntitrombotikProfilaksiKullanimDurumu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAntitrombotikProfilaksiKullanimDurumu.GetSKRSAntitrombotikProfilaksiKullanimDurumu_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string KODTIPIADI
        {
            get { return (string)this["KODTIPIADI"]; }
            set { this["KODTIPIADI"] = value; }
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public string KODU
        {
            get { return (string)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        protected SKRSAntitrombotikProfilaksiKullanimDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSAntitrombotikProfilaksiKullanimDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSAntitrombotikProfilaksiKullanimDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSAntitrombotikProfilaksiKullanimDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSAntitrombotikProfilaksiKullanimDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU", dataRow) { }
        protected SKRSAntitrombotikProfilaksiKullanimDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSANTITROMBOTIKPROFILAKSIKULLANIMDURUMU", dataRow, isImported) { }
        public SKRSAntitrombotikProfilaksiKullanimDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSAntitrombotikProfilaksiKullanimDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSAntitrombotikProfilaksiKullanimDurumu() : base() { }

    }
}