
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSAntihipertansifIlacKullanimDurumu")] 

    /// <summary>
    /// c3b1c7db-fc3a-4a8c-9c02-0583215eed24
    /// </summary>
    public  partial class SKRSAntihipertansifIlacKullanimDurumu : BaseSKRSCommonDef
    {
        public class SKRSAntihipertansifIlacKullanimDurumuList : TTObjectCollection<SKRSAntihipertansifIlacKullanimDurumu> { }
                    
        public class ChildSKRSAntihipertansifIlacKullanimDurumuCollection : TTObject.TTChildObjectCollection<SKRSAntihipertansifIlacKullanimDurumu>
        {
            public ChildSKRSAntihipertansifIlacKullanimDurumuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSAntihipertansifIlacKullanimDurumuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSAntihipertansifIlacKullanimDurumu_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSAntihipertansifIlacKullanimDurumu_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSAntihipertansifIlacKullanimDurumu_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSAntihipertansifIlacKullanimDurumu_Class() : base() { }
        }

        public static BindingList<SKRSAntihipertansifIlacKullanimDurumu.GetSKRSAntihipertansifIlacKullanimDurumu_Class> GetSKRSAntihipertansifIlacKullanimDurumu(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].QueryDefs["GetSKRSAntihipertansifIlacKullanimDurumu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAntihipertansifIlacKullanimDurumu.GetSKRSAntihipertansifIlacKullanimDurumu_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSAntihipertansifIlacKullanimDurumu.GetSKRSAntihipertansifIlacKullanimDurumu_Class> GetSKRSAntihipertansifIlacKullanimDurumu(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSANTIHIPERTANSIFILACKULLANIMDURUMU"].QueryDefs["GetSKRSAntihipertansifIlacKullanimDurumu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAntihipertansifIlacKullanimDurumu.GetSKRSAntihipertansifIlacKullanimDurumu_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSAntihipertansifIlacKullanimDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSAntihipertansifIlacKullanimDurumu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSAntihipertansifIlacKullanimDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSAntihipertansifIlacKullanimDurumu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSAntihipertansifIlacKullanimDurumu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSANTIHIPERTANSIFILACKULLANIMDURUMU", dataRow) { }
        protected SKRSAntihipertansifIlacKullanimDurumu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSANTIHIPERTANSIFILACKULLANIMDURUMU", dataRow, isImported) { }
        public SKRSAntihipertansifIlacKullanimDurumu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSAntihipertansifIlacKullanimDurumu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSAntihipertansifIlacKullanimDurumu() : base() { }

    }
}