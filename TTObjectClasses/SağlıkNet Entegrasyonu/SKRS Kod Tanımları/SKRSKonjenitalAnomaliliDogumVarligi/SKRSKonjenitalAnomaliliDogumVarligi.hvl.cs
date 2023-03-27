
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSKonjenitalAnomaliliDogumVarligi")] 

    /// <summary>
    /// 484b2fc2-d1a2-4675-872e-c2c56e72d921
    /// </summary>
    public  partial class SKRSKonjenitalAnomaliliDogumVarligi : BaseSKRSCommonDef
    {
        public class SKRSKonjenitalAnomaliliDogumVarligiList : TTObjectCollection<SKRSKonjenitalAnomaliliDogumVarligi> { }
                    
        public class ChildSKRSKonjenitalAnomaliliDogumVarligiCollection : TTObject.TTChildObjectCollection<SKRSKonjenitalAnomaliliDogumVarligi>
        {
            public ChildSKRSKonjenitalAnomaliliDogumVarligiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSKonjenitalAnomaliliDogumVarligiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSKonjenitalAnomaliliDogumVarligi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["KODTIPIADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSKonjenitalAnomaliliDogumVarligi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSKonjenitalAnomaliliDogumVarligi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSKonjenitalAnomaliliDogumVarligi_Class() : base() { }
        }

        public static BindingList<SKRSKonjenitalAnomaliliDogumVarligi.GetSKRSKonjenitalAnomaliliDogumVarligi_Class> GetSKRSKonjenitalAnomaliliDogumVarligi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].QueryDefs["GetSKRSKonjenitalAnomaliliDogumVarligi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKonjenitalAnomaliliDogumVarligi.GetSKRSKonjenitalAnomaliliDogumVarligi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSKonjenitalAnomaliliDogumVarligi.GetSKRSKonjenitalAnomaliliDogumVarligi_Class> GetSKRSKonjenitalAnomaliliDogumVarligi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].QueryDefs["GetSKRSKonjenitalAnomaliliDogumVarligi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSKonjenitalAnomaliliDogumVarligi.GetSKRSKonjenitalAnomaliliDogumVarligi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected SKRSKonjenitalAnomaliliDogumVarligi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSKonjenitalAnomaliliDogumVarligi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSKonjenitalAnomaliliDogumVarligi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSKonjenitalAnomaliliDogumVarligi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSKonjenitalAnomaliliDogumVarligi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSKONJENITALANOMALILIDOGUMVARLIGI", dataRow) { }
        protected SKRSKonjenitalAnomaliliDogumVarligi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSKONJENITALANOMALILIDOGUMVARLIGI", dataRow, isImported) { }
        public SKRSKonjenitalAnomaliliDogumVarligi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSKonjenitalAnomaliliDogumVarligi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSKonjenitalAnomaliliDogumVarligi() : base() { }

    }
}