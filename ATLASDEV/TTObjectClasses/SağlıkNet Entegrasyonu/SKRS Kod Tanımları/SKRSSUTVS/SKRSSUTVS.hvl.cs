
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSSUTVS")] 

    /// <summary>
    /// c9bdaced-ec0d-4520-9040-8691e06d710f
    /// </summary>
    public  partial class SKRSSUTVS : BaseSKRSDefinition
    {
        public class SKRSSUTVSList : TTObjectCollection<SKRSSUTVS> { }
                    
        public class ChildSKRSSUTVSCollection : TTObject.TTChildObjectCollection<SKRSSUTVS>
        {
            public ChildSKRSSUTVSCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSSUTVSCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSSUTVS_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? MSVSKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MSVSKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["MSVSKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MSVSADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MSVSADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["MSVSADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["SUTKODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSSUTVS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSSUTVS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSSUTVS_Class() : base() { }
        }

        public static BindingList<SKRSSUTVS.GetSKRSSUTVS_Class> GetSKRSSUTVS(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].QueryDefs["GetSKRSSUTVS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSSUTVS.GetSKRSSUTVS_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSSUTVS.GetSKRSSUTVS_Class> GetSKRSSUTVS(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSSUTVS"].QueryDefs["GetSKRSSUTVS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSSUTVS.GetSKRSSUTVS_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? MSVSKODU
        {
            get { return (int?)this["MSVSKODU"]; }
            set { this["MSVSKODU"] = value; }
        }

        public string MSVSADI
        {
            get { return (string)this["MSVSADI"]; }
            set { this["MSVSADI"] = value; }
        }

        public string SUTKODU
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
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

        protected SKRSSUTVS(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSSUTVS(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSSUTVS(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSSUTVS(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSSUTVS(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSSUTVS", dataRow) { }
        protected SKRSSUTVS(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSSUTVS", dataRow, isImported) { }
        public SKRSSUTVS(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSSUTVS(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSSUTVS() : base() { }

    }
}