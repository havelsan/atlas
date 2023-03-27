
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MalzemeGetData")] 

    /// <summary>
    /// MKYS Malzeme Eşleştirme
    /// </summary>
    public  partial class MalzemeGetData : TerminologyManagerDef
    {
        public class MalzemeGetDataList : TTObjectCollection<MalzemeGetData> { }
                    
        public class ChildMalzemeGetDataCollection : TTObject.TTChildObjectCollection<MalzemeGetData>
        {
            public ChildMalzemeGetDataCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMalzemeGetDataCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetmalzemeGetDataList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? malzemeKayitID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMEKAYITID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].AllPropertyDefs["MALZEMEKAYITID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string malzemeKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].AllPropertyDefs["MALZEMEKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string malzemeAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].AllPropertyDefs["MALZEMEADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? degisiklikTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEGISIKLIKTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].AllPropertyDefs["DEGISIKLIKTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string olcuBirimiID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLCUBIRIMIID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].AllPropertyDefs["OLCUBIRIMIID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string malzemeTurID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMETURID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].AllPropertyDefs["MALZEMETURID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string eskiMalzemeKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESKIMALZEMEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].AllPropertyDefs["ESKIMALZEMEKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? aktif
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKTIF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].AllPropertyDefs["AKTIF"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetmalzemeGetDataList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetmalzemeGetDataList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetmalzemeGetDataList_Class() : base() { }
        }

        public static BindingList<MalzemeGetData.GetmalzemeGetDataList_Class> GetmalzemeGetDataList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].QueryDefs["GetmalzemeGetDataList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MalzemeGetData.GetmalzemeGetDataList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MalzemeGetData.GetmalzemeGetDataList_Class> GetmalzemeGetDataList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MALZEMEGETDATA"].QueryDefs["GetmalzemeGetDataList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MalzemeGetData.GetmalzemeGetDataList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? malzemeKayitID
        {
            get { return (int?)this["MALZEMEKAYITID"]; }
            set { this["MALZEMEKAYITID"] = value; }
        }

        public string malzemeKodu
        {
            get { return (string)this["MALZEMEKODU"]; }
            set { this["MALZEMEKODU"] = value; }
        }

        public string malzemeAdi
        {
            get { return (string)this["MALZEMEADI"]; }
            set { this["MALZEMEADI"] = value; }
        }

        public DateTime? degisiklikTarihi
        {
            get { return (DateTime?)this["DEGISIKLIKTARIHI"]; }
            set { this["DEGISIKLIKTARIHI"] = value; }
        }

        public string olcuBirimiID
        {
            get { return (string)this["OLCUBIRIMIID"]; }
            set { this["OLCUBIRIMIID"] = value; }
        }

        public string malzemeTurID
        {
            get { return (string)this["MALZEMETURID"]; }
            set { this["MALZEMETURID"] = value; }
        }

        public string eskiMalzemeKodu
        {
            get { return (string)this["ESKIMALZEMEKODU"]; }
            set { this["ESKIMALZEMEKODU"] = value; }
        }

        public bool? aktif
        {
            get { return (bool?)this["AKTIF"]; }
            set { this["AKTIF"] = value; }
        }

    /// <summary>
    /// Günleme Tarihi
    /// </summary>
        public DateTime? gunlemeTarihi
        {
            get { return (DateTime?)this["GUNLEMETARIHI"]; }
            set { this["GUNLEMETARIHI"] = value; }
        }

        protected MalzemeGetData(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MalzemeGetData(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MalzemeGetData(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MalzemeGetData(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MalzemeGetData(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MALZEMEGETDATA", dataRow) { }
        protected MalzemeGetData(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MALZEMEGETDATA", dataRow, isImported) { }
        public MalzemeGetData(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MalzemeGetData(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MalzemeGetData() : base() { }

    }
}