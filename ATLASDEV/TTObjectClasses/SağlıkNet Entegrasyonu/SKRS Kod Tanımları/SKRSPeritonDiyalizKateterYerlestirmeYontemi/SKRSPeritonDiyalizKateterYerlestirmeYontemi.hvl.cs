
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSPeritonDiyalizKateterYerlestirmeYontemi")] 

    /// <summary>
    /// 1ba51ab0-da51-4abf-828a-ac386459d265
    /// </summary>
    public  partial class SKRSPeritonDiyalizKateterYerlestirmeYontemi : BaseSKRSCommonDef
    {
        public class SKRSPeritonDiyalizKateterYerlestirmeYontemiList : TTObjectCollection<SKRSPeritonDiyalizKateterYerlestirmeYontemi> { }
                    
        public class ChildSKRSPeritonDiyalizKateterYerlestirmeYontemiCollection : TTObject.TTChildObjectCollection<SKRSPeritonDiyalizKateterYerlestirmeYontemi>
        {
            public ChildSKRSPeritonDiyalizKateterYerlestirmeYontemiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSPeritonDiyalizKateterYerlestirmeYontemiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSPeritonDiyalizKateterYerlestirmeYontemi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KODTIPIADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSPeritonDiyalizKateterYerlestirmeYontemi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSPeritonDiyalizKateterYerlestirmeYontemi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSPeritonDiyalizKateterYerlestirmeYontemi_Class() : base() { }
        }

        public static BindingList<SKRSPeritonDiyalizKateterYerlestirmeYontemi.GetSKRSPeritonDiyalizKateterYerlestirmeYontemi_Class> GetSKRSPeritonDiyalizKateterYerlestirmeYontemi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].QueryDefs["GetSKRSPeritonDiyalizKateterYerlestirmeYontemi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPeritonDiyalizKateterYerlestirmeYontemi.GetSKRSPeritonDiyalizKateterYerlestirmeYontemi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSPeritonDiyalizKateterYerlestirmeYontemi.GetSKRSPeritonDiyalizKateterYerlestirmeYontemi_Class> GetSKRSPeritonDiyalizKateterYerlestirmeYontemi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI"].QueryDefs["GetSKRSPeritonDiyalizKateterYerlestirmeYontemi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSPeritonDiyalizKateterYerlestirmeYontemi.GetSKRSPeritonDiyalizKateterYerlestirmeYontemi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSPeritonDiyalizKateterYerlestirmeYontemi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSPeritonDiyalizKateterYerlestirmeYontemi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSPeritonDiyalizKateterYerlestirmeYontemi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSPeritonDiyalizKateterYerlestirmeYontemi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSPeritonDiyalizKateterYerlestirmeYontemi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI", dataRow) { }
        protected SKRSPeritonDiyalizKateterYerlestirmeYontemi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSPERITONDIYALIZKATETERYERLESTIRMEYONTEMI", dataRow, isImported) { }
        public SKRSPeritonDiyalizKateterYerlestirmeYontemi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSPeritonDiyalizKateterYerlestirmeYontemi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSPeritonDiyalizKateterYerlestirmeYontemi() : base() { }

    }
}