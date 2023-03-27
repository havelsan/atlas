
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSKurumlar")] 

    /// <summary>
    /// c3eade04-4f91-5dab-e043-14031b0ac9f9
    /// </summary>
    public  partial class SKRSKurumlar : BaseSKRSDefinition
    {
        public class SKRSKurumlarList : TTObjectCollection<SKRSKurumlar> { }
                    
        public class ChildSKRSKurumlarCollection : TTObject.TTChildObjectCollection<SKRSKurumlar>
        {
            public ChildSKRSKurumlarCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSKurumlarCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSKurumlar_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? KODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ILKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["ILKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ILCEKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILCEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["ILCEKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string KURUMTIPI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUMTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["KURUMTIPI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? KURUMTURKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUMTURKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["KURUMTURKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? BASAMAKSEVIYESI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASAMAKSEVIYESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["BASAMAKSEVIYESI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string TELETIPONEK
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELETIPONEK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].AllPropertyDefs["TELETIPONEK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSKurumlar_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSKurumlar_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSKurumlar_Class() : base() { }
        }

        public static BindingList<SKRSKurumlar.GetSKRSKurumlar_Class> GetSKRSKurumlar(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].QueryDefs["GetSKRSKurumlar"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKurumlar.GetSKRSKurumlar_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKurumlar.GetSKRSKurumlar_Class> GetSKRSKurumlar(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].QueryDefs["GetSKRSKurumlar"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKurumlar.GetSKRSKurumlar_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKurumlar> GetByKodu(TTObjectContext objectContext, string KODU, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].QueryDefs["GetByKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KODU", KODU);

            return ((ITTQuery)objectContext).QueryObjects<SKRSKurumlar>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<SKRSKurumlar> GetSKRSKurumList(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKURUMLAR"].QueryDefs["GetSKRSKurumList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SKRSKurumlar>(queryDef, paramList, injectionSQL);
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public int? KODU
        {
            get { return (int?)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public int? ILKODU
        {
            get { return (int?)this["ILKODU"]; }
            set { this["ILKODU"] = value; }
        }

        public int? ILCEKODU
        {
            get { return (int?)this["ILCEKODU"]; }
            set { this["ILCEKODU"] = value; }
        }

        public string KURUMTIPI
        {
            get { return (string)this["KURUMTIPI"]; }
            set { this["KURUMTIPI"] = value; }
        }

        public int? KURUMTURKODU
        {
            get { return (int?)this["KURUMTURKODU"]; }
            set { this["KURUMTURKODU"] = value; }
        }

        public int? BASAMAKSEVIYESI
        {
            get { return (int?)this["BASAMAKSEVIYESI"]; }
            set { this["BASAMAKSEVIYESI"] = value; }
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

        public string TELETIPONEK
        {
            get { return (string)this["TELETIPONEK"]; }
            set { this["TELETIPONEK"] = value; }
        }

        protected SKRSKurumlar(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSKurumlar(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSKurumlar(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSKurumlar(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSKurumlar(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSKURUMLAR", dataRow) { }
        protected SKRSKurumlar(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSKURUMLAR", dataRow, isImported) { }
        public SKRSKurumlar(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSKurumlar(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSKurumlar() : base() { }

    }
}