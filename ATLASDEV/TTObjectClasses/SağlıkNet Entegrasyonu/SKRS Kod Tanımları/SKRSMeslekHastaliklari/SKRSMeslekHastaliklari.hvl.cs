
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSMeslekHastaliklari")] 

    /// <summary>
    /// c3eaea6c-3a71-5eb7-e043-14031b0af492
    /// </summary>
    public  partial class SKRSMeslekHastaliklari : BaseSKRSDefinition
    {
        public class SKRSMeslekHastaliklariList : TTObjectCollection<SKRSMeslekHastaliklari> { }
                    
        public class ChildSKRSMeslekHastaliklariCollection : TTObject.TTChildObjectCollection<SKRSMeslekHastaliklari>
        {
            public ChildSKRSMeslekHastaliklariCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSMeslekHastaliklariCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSMeslekHastaliklari_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ICDADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICDADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["ICDADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["ICDKODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSMeslekHastaliklari_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSMeslekHastaliklari_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSMeslekHastaliklari_Class() : base() { }
        }

        public static BindingList<SKRSMeslekHastaliklari.GetSKRSMeslekHastaliklari_Class> GetSKRSMeslekHastaliklari(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].QueryDefs["GetSKRSMeslekHastaliklari"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSMeslekHastaliklari.GetSKRSMeslekHastaliklari_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSMeslekHastaliklari.GetSKRSMeslekHastaliklari_Class> GetSKRSMeslekHastaliklari(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKHASTALIKLARI"].QueryDefs["GetSKRSMeslekHastaliklari"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSMeslekHastaliklari.GetSKRSMeslekHastaliklari_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        public string ICDADI
        {
            get { return (string)this["ICDADI"]; }
            set { this["ICDADI"] = value; }
        }

        public string ICDKODU
        {
            get { return (string)this["ICDKODU"]; }
            set { this["ICDKODU"] = value; }
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

        protected SKRSMeslekHastaliklari(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSMeslekHastaliklari(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSMeslekHastaliklari(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSMeslekHastaliklari(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSMeslekHastaliklari(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSMESLEKHASTALIKLARI", dataRow) { }
        protected SKRSMeslekHastaliklari(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSMESLEKHASTALIKLARI", dataRow, isImported) { }
        public SKRSMeslekHastaliklari(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSMeslekHastaliklari(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSMeslekHastaliklari() : base() { }

    }
}