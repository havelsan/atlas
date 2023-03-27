
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSTibbiBiyokimyaAkilciTestIstemiListesi")] 

    /// <summary>
    /// cee9ef3e-7b56-4a37-bf7b-67eb160033e8
    /// </summary>
    public  partial class SKRSTibbiBiyokimyaAkilciTestIstemiListesi : BaseSKRSDefinition
    {
        public class SKRSTibbiBiyokimyaAkilciTestIstemiListesiList : TTObjectCollection<SKRSTibbiBiyokimyaAkilciTestIstemiListesi> { }
                    
        public class ChildSKRSTibbiBiyokimyaAkilciTestIstemiListesiCollection : TTObject.TTChildObjectCollection<SKRSTibbiBiyokimyaAkilciTestIstemiListesi>
        {
            public ChildSKRSTibbiBiyokimyaAkilciTestIstemiListesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSTibbiBiyokimyaAkilciTestIstemiListesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["SUTKODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["ISTEMSURESI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi_Class() : base() { }
        }

        public static BindingList<SKRSTibbiBiyokimyaAkilciTestIstemiListesi.GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi_Class> GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].QueryDefs["GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTibbiBiyokimyaAkilciTestIstemiListesi.GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSTibbiBiyokimyaAkilciTestIstemiListesi.GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi_Class> GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI"].QueryDefs["GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTibbiBiyokimyaAkilciTestIstemiListesi.GetSKRSTibbiBiyokimyaAkilciTestIstemiListesi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        protected SKRSTibbiBiyokimyaAkilciTestIstemiListesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSTibbiBiyokimyaAkilciTestIstemiListesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSTibbiBiyokimyaAkilciTestIstemiListesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSTibbiBiyokimyaAkilciTestIstemiListesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSTibbiBiyokimyaAkilciTestIstemiListesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI", dataRow) { }
        protected SKRSTibbiBiyokimyaAkilciTestIstemiListesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSTIBBIBIYOKIMYAAKILCITESTISTEMILISTESI", dataRow, isImported) { }
        public SKRSTibbiBiyokimyaAkilciTestIstemiListesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSTibbiBiyokimyaAkilciTestIstemiListesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSTibbiBiyokimyaAkilciTestIstemiListesi() : base() { }

    }
}