
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSNTPNUMUNEDURUMBILGISI")] 

    /// <summary>
    /// ece57deb-3c0c-4801-a65f-8123e48f3912
    /// </summary>
    public  partial class SKRSNTPNUMUNEDURUMBILGISI : BaseSKRSDefinition
    {
        public class SKRSNTPNUMUNEDURUMBILGISIList : TTObjectCollection<SKRSNTPNUMUNEDURUMBILGISI> { }
                    
        public class ChildSKRSNTPNUMUNEDURUMBILGISICollection : TTObject.TTChildObjectCollection<SKRSNTPNUMUNEDURUMBILGISI>
        {
            public ChildSKRSNTPNUMUNEDURUMBILGISICollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSNTPNUMUNEDURUMBILGISICollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSNTPNUMUNEDURUMBILGISI_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSNTPNUMUNEDURUMBILGISI_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSNTPNUMUNEDURUMBILGISI_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSNTPNUMUNEDURUMBILGISI_Class() : base() { }
        }

        public static BindingList<SKRSNTPNUMUNEDURUMBILGISI.GetSKRSNTPNUMUNEDURUMBILGISI_Class> GetSKRSNTPNUMUNEDURUMBILGISI(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].QueryDefs["GetSKRSNTPNUMUNEDURUMBILGISI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSNTPNUMUNEDURUMBILGISI.GetSKRSNTPNUMUNEDURUMBILGISI_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSNTPNUMUNEDURUMBILGISI.GetSKRSNTPNUMUNEDURUMBILGISI_Class> GetSKRSNTPNUMUNEDURUMBILGISI(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPNUMUNEDURUMBILGISI"].QueryDefs["GetSKRSNTPNUMUNEDURUMBILGISI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSNTPNUMUNEDURUMBILGISI.GetSKRSNTPNUMUNEDURUMBILGISI_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        protected SKRSNTPNUMUNEDURUMBILGISI(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSNTPNUMUNEDURUMBILGISI(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSNTPNUMUNEDURUMBILGISI(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSNTPNUMUNEDURUMBILGISI(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSNTPNUMUNEDURUMBILGISI(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSNTPNUMUNEDURUMBILGISI", dataRow) { }
        protected SKRSNTPNUMUNEDURUMBILGISI(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSNTPNUMUNEDURUMBILGISI", dataRow, isImported) { }
        public SKRSNTPNUMUNEDURUMBILGISI(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSNTPNUMUNEDURUMBILGISI(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSNTPNUMUNEDURUMBILGISI() : base() { }

    }
}