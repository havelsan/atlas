
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSAilePlanlamasiAPYontemiKullanmamaNedeni")] 

    /// <summary>
    /// 084620ca-5f25-469b-af47-158f760f16b5
    /// </summary>
    public  partial class SKRSAilePlanlamasiAPYontemiKullanmamaNedeni : BaseSKRSCommonDef
    {
        public class SKRSAilePlanlamasiAPYontemiKullanmamaNedeniList : TTObjectCollection<SKRSAilePlanlamasiAPYontemiKullanmamaNedeni> { }
                    
        public class ChildSKRSAilePlanlamasiAPYontemiKullanmamaNedeniCollection : TTObject.TTChildObjectCollection<SKRSAilePlanlamasiAPYontemiKullanmamaNedeni>
        {
            public ChildSKRSAilePlanlamasiAPYontemiKullanmamaNedeniCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSAilePlanlamasiAPYontemiKullanmamaNedeniCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni_Class() : base() { }
        }

        public static BindingList<SKRSAilePlanlamasiAPYontemiKullanmamaNedeni.GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni_Class> GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].QueryDefs["GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAilePlanlamasiAPYontemiKullanmamaNedeni.GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSAilePlanlamasiAPYontemiKullanmamaNedeni.GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni_Class> GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI"].QueryDefs["GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAilePlanlamasiAPYontemiKullanmamaNedeni.GetSKRSAilePlanlamasiAPYontemiKullanmamaNedeni_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSAilePlanlamasiAPYontemiKullanmamaNedeni(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSAilePlanlamasiAPYontemiKullanmamaNedeni(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSAilePlanlamasiAPYontemiKullanmamaNedeni(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSAilePlanlamasiAPYontemiKullanmamaNedeni(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSAilePlanlamasiAPYontemiKullanmamaNedeni(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI", dataRow) { }
        protected SKRSAilePlanlamasiAPYontemiKullanmamaNedeni(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSAILEPLANLAMASIAPYONTEMIKULLANMAMANEDENI", dataRow, isImported) { }
        public SKRSAilePlanlamasiAPYontemiKullanmamaNedeni(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSAilePlanlamasiAPYontemiKullanmamaNedeni(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSAilePlanlamasiAPYontemiKullanmamaNedeni() : base() { }

    }
}