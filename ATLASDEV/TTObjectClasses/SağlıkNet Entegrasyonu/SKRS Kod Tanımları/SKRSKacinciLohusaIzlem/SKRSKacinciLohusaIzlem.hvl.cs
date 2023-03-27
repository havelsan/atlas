
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSKacinciLohusaIzlem")] 

    /// <summary>
    /// 05d2b394-9c2b-4b2a-8a3a-8b5023187502
    /// </summary>
    public  partial class SKRSKacinciLohusaIzlem : BaseSKRSDefinition
    {
        public class SKRSKacinciLohusaIzlemList : TTObjectCollection<SKRSKacinciLohusaIzlem> { }
                    
        public class ChildSKRSKacinciLohusaIzlemCollection : TTObject.TTChildObjectCollection<SKRSKacinciLohusaIzlem>
        {
            public ChildSKRSKacinciLohusaIzlemCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSKacinciLohusaIzlemCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSKacinciLohusaIzlem_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ILKUYGULANMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILKUYGULANMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["ILKUYGULANMATARIHI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? SONUYGULANMATARIHI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONUYGULANMATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].AllPropertyDefs["SONUYGULANMATARIHI"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSKacinciLohusaIzlem_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSKacinciLohusaIzlem_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSKacinciLohusaIzlem_Class() : base() { }
        }

        public static BindingList<SKRSKacinciLohusaIzlem.GetSKRSKacinciLohusaIzlem_Class> GetSKRSKacinciLohusaIzlem(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].QueryDefs["GetSKRSKacinciLohusaIzlem"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKacinciLohusaIzlem.GetSKRSKacinciLohusaIzlem_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKacinciLohusaIzlem.GetSKRSKacinciLohusaIzlem_Class> GetSKRSKacinciLohusaIzlem(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKACINCILOHUSAIZLEM"].QueryDefs["GetSKRSKacinciLohusaIzlem"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKacinciLohusaIzlem.GetSKRSKacinciLohusaIzlem_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        public int? ILKUYGULANMATARIHI
        {
            get { return (int?)this["ILKUYGULANMATARIHI"]; }
            set { this["ILKUYGULANMATARIHI"] = value; }
        }

        public int? SONUYGULANMATARIHI
        {
            get { return (int?)this["SONUYGULANMATARIHI"]; }
            set { this["SONUYGULANMATARIHI"] = value; }
        }

        protected SKRSKacinciLohusaIzlem(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSKacinciLohusaIzlem(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSKacinciLohusaIzlem(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSKacinciLohusaIzlem(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSKacinciLohusaIzlem(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSKACINCILOHUSAIZLEM", dataRow) { }
        protected SKRSKacinciLohusaIzlem(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSKACINCILOHUSAIZLEM", dataRow, isImported) { }
        public SKRSKacinciLohusaIzlem(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSKacinciLohusaIzlem(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSKacinciLohusaIzlem() : base() { }

    }
}