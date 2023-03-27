
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSKuduzRiskliTemasDegerlendirmeDurumu")] 

    /// <summary>
    /// 67be197d-3af4-40f9-b40e-59b6e86d8b44
    /// </summary>
    public  partial class SKRSKuduzRiskliTemasDegerlendirmeDurumu : BaseSKRSDefinition
    {
        public class SKRSKuduzRiskliTemasDegerlendirmeDurumuList : TTObjectCollection<SKRSKuduzRiskliTemasDegerlendirmeDurumu> { }
                    
        public class ChildSKRSKuduzRiskliTemasDegerlendirmeDurumuCollection : TTObject.TTChildObjectCollection<SKRSKuduzRiskliTemasDegerlendirmeDurumu>
        {
            public ChildSKRSKuduzRiskliTemasDegerlendirmeDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSKuduzRiskliTemasDegerlendirmeDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSKuduzRiskliTemasDegerlendirmeDurumu_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSKuduzRiskliTemasDegerlendirmeDurumu_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSKuduzRiskliTemasDegerlendirmeDurumu_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSKuduzRiskliTemasDegerlendirmeDurumu_Class() : base() { }
        }

        public static BindingList<SKRSKuduzRiskliTemasDegerlendirmeDurumu.GetSKRSKuduzRiskliTemasDegerlendirmeDurumu_Class> GetSKRSKuduzRiskliTemasDegerlendirmeDurumu(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].QueryDefs["GetSKRSKuduzRiskliTemasDegerlendirmeDurumu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKuduzRiskliTemasDegerlendirmeDurumu.GetSKRSKuduzRiskliTemasDegerlendirmeDurumu_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKuduzRiskliTemasDegerlendirmeDurumu.GetSKRSKuduzRiskliTemasDegerlendirmeDurumu_Class> GetSKRSKuduzRiskliTemasDegerlendirmeDurumu(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU"].QueryDefs["GetSKRSKuduzRiskliTemasDegerlendirmeDurumu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKuduzRiskliTemasDegerlendirmeDurumu.GetSKRSKuduzRiskliTemasDegerlendirmeDurumu_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public string KODTIPIADI
        {
            get { return (string)this["KODTIPIADI"]; }
            set { this["KODTIPIADI"] = value; }
        }

        public string KODU
        {
            get { return (string)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        protected SKRSKuduzRiskliTemasDegerlendirmeDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSKuduzRiskliTemasDegerlendirmeDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSKuduzRiskliTemasDegerlendirmeDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSKuduzRiskliTemasDegerlendirmeDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSKuduzRiskliTemasDegerlendirmeDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU", dataRow) { }
        protected SKRSKuduzRiskliTemasDegerlendirmeDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSKUDUZRISKLITEMASDEGERLENDIRMEDURUMU", dataRow, isImported) { }
        public SKRSKuduzRiskliTemasDegerlendirmeDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSKuduzRiskliTemasDegerlendirmeDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSKuduzRiskliTemasDegerlendirmeDurumu() : base() { }

    }
}