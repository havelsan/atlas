
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSNTPANALIZSONUCUBIRIMI")] 

    /// <summary>
    /// 64b3457a-5568-440e-9125-79fd2fa16d2a
    /// </summary>
    public  partial class SKRSNTPANALIZSONUCUBIRIMI : BaseSKRSDefinition
    {
        public class SKRSNTPANALIZSONUCUBIRIMIList : TTObjectCollection<SKRSNTPANALIZSONUCUBIRIMI> { }
                    
        public class ChildSKRSNTPANALIZSONUCUBIRIMICollection : TTObject.TTChildObjectCollection<SKRSNTPANALIZSONUCUBIRIMI>
        {
            public ChildSKRSNTPANALIZSONUCUBIRIMICollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSNTPANALIZSONUCUBIRIMICollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSNTPANALIZSONUCUBIRIMI_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSNTPANALIZSONUCUBIRIMI_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSNTPANALIZSONUCUBIRIMI_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSNTPANALIZSONUCUBIRIMI_Class() : base() { }
        }

        public static BindingList<SKRSNTPANALIZSONUCUBIRIMI.GetSKRSNTPANALIZSONUCUBIRIMI_Class> GetSKRSNTPANALIZSONUCUBIRIMI(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].QueryDefs["GetSKRSNTPANALIZSONUCUBIRIMI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSNTPANALIZSONUCUBIRIMI.GetSKRSNTPANALIZSONUCUBIRIMI_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSNTPANALIZSONUCUBIRIMI.GetSKRSNTPANALIZSONUCUBIRIMI_Class> GetSKRSNTPANALIZSONUCUBIRIMI(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSNTPANALIZSONUCUBIRIMI"].QueryDefs["GetSKRSNTPANALIZSONUCUBIRIMI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSNTPANALIZSONUCUBIRIMI.GetSKRSNTPANALIZSONUCUBIRIMI_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        protected SKRSNTPANALIZSONUCUBIRIMI(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSNTPANALIZSONUCUBIRIMI(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSNTPANALIZSONUCUBIRIMI(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSNTPANALIZSONUCUBIRIMI(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSNTPANALIZSONUCUBIRIMI(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSNTPANALIZSONUCUBIRIMI", dataRow) { }
        protected SKRSNTPANALIZSONUCUBIRIMI(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSNTPANALIZSONUCUBIRIMI", dataRow, isImported) { }
        public SKRSNTPANALIZSONUCUBIRIMI(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSNTPANALIZSONUCUBIRIMI(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSNTPANALIZSONUCUBIRIMI() : base() { }

    }
}