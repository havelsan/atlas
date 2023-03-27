
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSAdresTipi")] 

    /// <summary>
    /// 35f4968a-3e72-41ce-9ae4-f4d22f90ea2e
    /// </summary>
    public  partial class SKRSAdresTipi : BaseSKRSCommonDef
    {
        public class SKRSAdresTipiList : TTObjectCollection<SKRSAdresTipi> { }
                    
        public class ChildSKRSAdresTipiCollection : TTObject.TTChildObjectCollection<SKRSAdresTipi>
        {
            public ChildSKRSAdresTipiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSAdresTipiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSAdresTipi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSAdresTipi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSAdresTipi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSAdresTipi_Class() : base() { }
        }

        public static BindingList<SKRSAdresTipi> GetSKRSAdresTipiByKodu(TTObjectContext objectContext, string KODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].QueryDefs["GetSKRSAdresTipiByKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KODU", KODU);

            return ((ITTQuery)objectContext).QueryObjects<SKRSAdresTipi>(queryDef, paramList);
        }

        public static BindingList<SKRSAdresTipi.GetSKRSAdresTipi_Class> GetSKRSAdresTipi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].QueryDefs["GetSKRSAdresTipi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAdresTipi.GetSKRSAdresTipi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSAdresTipi.GetSKRSAdresTipi_Class> GetSKRSAdresTipi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSADRESTIPI"].QueryDefs["GetSKRSAdresTipi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAdresTipi.GetSKRSAdresTipi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSAdresTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSAdresTipi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSAdresTipi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSAdresTipi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSAdresTipi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSADRESTIPI", dataRow) { }
        protected SKRSAdresTipi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSADRESTIPI", dataRow, isImported) { }
        public SKRSAdresTipi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSAdresTipi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSAdresTipi() : base() { }

    }
}