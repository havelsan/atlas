
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSAsininUygulamaSekli")] 

    /// <summary>
    /// f20210e0-d780-4961-87eb-3323000b7dbb
    /// </summary>
    public  partial class SKRSAsininUygulamaSekli : BaseSKRSCommonDef
    {
        public class SKRSAsininUygulamaSekliList : TTObjectCollection<SKRSAsininUygulamaSekli> { }
                    
        public class ChildSKRSAsininUygulamaSekliCollection : TTObject.TTChildObjectCollection<SKRSAsininUygulamaSekli>
        {
            public ChildSKRSAsininUygulamaSekliCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSAsininUygulamaSekliCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSAsininUygulamaSekli_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSAsininUygulamaSekli_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSAsininUygulamaSekli_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSAsininUygulamaSekli_Class() : base() { }
        }

        public static BindingList<SKRSAsininUygulamaSekli.GetSKRSAsininUygulamaSekli_Class> GetSKRSAsininUygulamaSekli(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].QueryDefs["GetSKRSAsininUygulamaSekli"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAsininUygulamaSekli.GetSKRSAsininUygulamaSekli_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSAsininUygulamaSekli.GetSKRSAsininUygulamaSekli_Class> GetSKRSAsininUygulamaSekli(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSASININUYGULAMASEKLI"].QueryDefs["GetSKRSAsininUygulamaSekli"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSAsininUygulamaSekli.GetSKRSAsininUygulamaSekli_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateVaccineDetailsCollection()
        {
            _VaccineDetails = new VaccineDetails.ChildVaccineDetailsCollection(this, new Guid("74844f45-770c-4fd2-87c8-ac699cfffc7a"));
            ((ITTChildObjectCollection)_VaccineDetails).GetChildren();
        }

        protected VaccineDetails.ChildVaccineDetailsCollection _VaccineDetails = null;
        public VaccineDetails.ChildVaccineDetailsCollection VaccineDetails
        {
            get
            {
                if (_VaccineDetails == null)
                    CreateVaccineDetailsCollection();
                return _VaccineDetails;
            }
        }

        protected SKRSAsininUygulamaSekli(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSAsininUygulamaSekli(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSAsininUygulamaSekli(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSAsininUygulamaSekli(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSAsininUygulamaSekli(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSASININUYGULAMASEKLI", dataRow) { }
        protected SKRSAsininUygulamaSekli(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSASININUYGULAMASEKLI", dataRow, isImported) { }
        public SKRSAsininUygulamaSekli(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSAsininUygulamaSekli(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSAsininUygulamaSekli() : base() { }

    }
}