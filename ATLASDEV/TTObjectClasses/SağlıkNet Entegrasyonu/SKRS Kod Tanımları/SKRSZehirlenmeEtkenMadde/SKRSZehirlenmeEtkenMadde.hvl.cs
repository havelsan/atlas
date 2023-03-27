
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSZehirlenmeEtkenMadde")] 

    /// <summary>
    /// c3eb2b86-0409-6623-e043-14031b0abf48
    /// </summary>
    public  partial class SKRSZehirlenmeEtkenMadde : BaseSKRSDefinition
    {
        public class SKRSZehirlenmeEtkenMaddeList : TTObjectCollection<SKRSZehirlenmeEtkenMadde> { }
                    
        public class ChildSKRSZehirlenmeEtkenMaddeCollection : TTObject.TTChildObjectCollection<SKRSZehirlenmeEtkenMadde>
        {
            public ChildSKRSZehirlenmeEtkenMaddeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSZehirlenmeEtkenMaddeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSZehirlenmeEtkenMadde_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string YENIKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YENIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["YENIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ICDKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICDKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["ICDKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? USTBOLUMKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USTBOLUMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["USTBOLUMKODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string GUNCELLENMETARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSZehirlenmeEtkenMadde_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSZehirlenmeEtkenMadde_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSZehirlenmeEtkenMadde_Class() : base() { }
        }

        public static BindingList<SKRSZehirlenmeEtkenMadde.GetSKRSZehirlenmeEtkenMadde_Class> GetSKRSZehirlenmeEtkenMadde(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].QueryDefs["GetSKRSZehirlenmeEtkenMadde"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSZehirlenmeEtkenMadde.GetSKRSZehirlenmeEtkenMadde_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSZehirlenmeEtkenMadde.GetSKRSZehirlenmeEtkenMadde_Class> GetSKRSZehirlenmeEtkenMadde(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSZEHIRLENMEETKENMADDE"].QueryDefs["GetSKRSZehirlenmeEtkenMadde"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSZehirlenmeEtkenMadde.GetSKRSZehirlenmeEtkenMadde_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        public string YENIKODU
        {
            get { return (string)this["YENIKODU"]; }
            set { this["YENIKODU"] = value; }
        }

        public string ICDKODU
        {
            get { return (string)this["ICDKODU"]; }
            set { this["ICDKODU"] = value; }
        }

        public int? USTBOLUMKODU
        {
            get { return (int?)this["USTBOLUMKODU"]; }
            set { this["USTBOLUMKODU"] = value; }
        }

        public DateTime? OLUSTURULMATARIHI1
        {
            get { return (DateTime?)this["OLUSTURULMATARIHI1"]; }
            set { this["OLUSTURULMATARIHI1"] = value; }
        }

        public string GUNCELLENMETARIHI1
        {
            get { return (string)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        protected SKRSZehirlenmeEtkenMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSZehirlenmeEtkenMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSZehirlenmeEtkenMadde(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSZehirlenmeEtkenMadde(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSZehirlenmeEtkenMadde(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSZEHIRLENMEETKENMADDE", dataRow) { }
        protected SKRSZehirlenmeEtkenMadde(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSZEHIRLENMEETKENMADDE", dataRow, isImported) { }
        public SKRSZehirlenmeEtkenMadde(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSZehirlenmeEtkenMadde(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSZehirlenmeEtkenMadde() : base() { }

    }
}