
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSGebelikBildirimiZorunluRiskFaktorleri")] 

    /// <summary>
    /// 2d982b17-23c9-48d8-93a4-1c7f164c8ad8
    /// </summary>
    public  partial class SKRSGebelikBildirimiZorunluRiskFaktorleri : BaseSKRSDefinition
    {
        public class SKRSGebelikBildirimiZorunluRiskFaktorleriList : TTObjectCollection<SKRSGebelikBildirimiZorunluRiskFaktorleri> { }
                    
        public class ChildSKRSGebelikBildirimiZorunluRiskFaktorleriCollection : TTObject.TTChildObjectCollection<SKRSGebelikBildirimiZorunluRiskFaktorleri>
        {
            public ChildSKRSGebelikBildirimiZorunluRiskFaktorleriCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSGebelikBildirimiZorunluRiskFaktorleriCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSGebelikBildirimiZorunluRiskFaktorleri_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSGebelikBildirimiZorunluRiskFaktorleri_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSGebelikBildirimiZorunluRiskFaktorleri_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSGebelikBildirimiZorunluRiskFaktorleri_Class() : base() { }
        }

        public static BindingList<SKRSGebelikBildirimiZorunluRiskFaktorleri.GetSKRSGebelikBildirimiZorunluRiskFaktorleri_Class> GetSKRSGebelikBildirimiZorunluRiskFaktorleri(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].QueryDefs["GetSKRSGebelikBildirimiZorunluRiskFaktorleri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGebelikBildirimiZorunluRiskFaktorleri.GetSKRSGebelikBildirimiZorunluRiskFaktorleri_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSGebelikBildirimiZorunluRiskFaktorleri.GetSKRSGebelikBildirimiZorunluRiskFaktorleri_Class> GetSKRSGebelikBildirimiZorunluRiskFaktorleri(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI"].QueryDefs["GetSKRSGebelikBildirimiZorunluRiskFaktorleri"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSGebelikBildirimiZorunluRiskFaktorleri.GetSKRSGebelikBildirimiZorunluRiskFaktorleri_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        protected SKRSGebelikBildirimiZorunluRiskFaktorleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSGebelikBildirimiZorunluRiskFaktorleri(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSGebelikBildirimiZorunluRiskFaktorleri(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSGebelikBildirimiZorunluRiskFaktorleri(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSGebelikBildirimiZorunluRiskFaktorleri(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI", dataRow) { }
        protected SKRSGebelikBildirimiZorunluRiskFaktorleri(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSGEBELIKBILDIRIMIZORUNLURISKFAKTORLERI", dataRow, isImported) { }
        public SKRSGebelikBildirimiZorunluRiskFaktorleri(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSGebelikBildirimiZorunluRiskFaktorleri(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSGebelikBildirimiZorunluRiskFaktorleri() : base() { }

    }
}