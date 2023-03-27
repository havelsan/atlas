
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSTedaviSonucuMaddeBagimliligi")] 

    /// <summary>
    /// d321b039-82fd-4bd2-b906-44dda0258ab6
    /// </summary>
    public  partial class SKRSTedaviSonucuMaddeBagimliligi : BaseSKRSCommonDef
    {
        public class SKRSTedaviSonucuMaddeBagimliligiList : TTObjectCollection<SKRSTedaviSonucuMaddeBagimliligi> { }
                    
        public class ChildSKRSTedaviSonucuMaddeBagimliligiCollection : TTObject.TTChildObjectCollection<SKRSTedaviSonucuMaddeBagimliligi>
        {
            public ChildSKRSTedaviSonucuMaddeBagimliligiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSTedaviSonucuMaddeBagimliligiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSTedaviSonucuMaddeBagimliligi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSTedaviSonucuMaddeBagimliligi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSTedaviSonucuMaddeBagimliligi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSTedaviSonucuMaddeBagimliligi_Class() : base() { }
        }

        public static BindingList<SKRSTedaviSonucuMaddeBagimliligi.GetSKRSTedaviSonucuMaddeBagimliligi_Class> GetSKRSTedaviSonucuMaddeBagimliligi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].QueryDefs["GetSKRSTedaviSonucuMaddeBagimliligi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTedaviSonucuMaddeBagimliligi.GetSKRSTedaviSonucuMaddeBagimliligi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSTedaviSonucuMaddeBagimliligi.GetSKRSTedaviSonucuMaddeBagimliligi_Class> GetSKRSTedaviSonucuMaddeBagimliligi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTEDAVISONUCUMADDEBAGIMLILIGI"].QueryDefs["GetSKRSTedaviSonucuMaddeBagimliligi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTedaviSonucuMaddeBagimliligi.GetSKRSTedaviSonucuMaddeBagimliligi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSTedaviSonucuMaddeBagimliligi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSTedaviSonucuMaddeBagimliligi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSTedaviSonucuMaddeBagimliligi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSTedaviSonucuMaddeBagimliligi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSTedaviSonucuMaddeBagimliligi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSTEDAVISONUCUMADDEBAGIMLILIGI", dataRow) { }
        protected SKRSTedaviSonucuMaddeBagimliligi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSTEDAVISONUCUMADDEBAGIMLILIGI", dataRow, isImported) { }
        public SKRSTedaviSonucuMaddeBagimliligi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSTedaviSonucuMaddeBagimliligi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSTedaviSonucuMaddeBagimliligi() : base() { }

    }
}