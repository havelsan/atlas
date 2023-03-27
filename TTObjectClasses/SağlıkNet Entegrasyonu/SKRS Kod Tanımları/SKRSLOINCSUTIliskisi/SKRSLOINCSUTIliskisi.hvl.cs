
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSLOINCSUTIliskisi")] 

    /// <summary>
    /// 4733b4b6-b779-4b5d-adea-7cee1a934d25
    /// </summary>
    public  partial class SKRSLOINCSUTIliskisi : BaseSKRSDefinition
    {
        public class SKRSLOINCSUTIliskisiList : TTObjectCollection<SKRSLOINCSUTIliskisi> { }
                    
        public class ChildSKRSLOINCSUTIliskisiCollection : TTObject.TTChildObjectCollection<SKRSLOINCSUTIliskisi>
        {
            public ChildSKRSLOINCSUTIliskisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSLOINCSUTIliskisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSLOINCSUTIliskisi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string LOINCNUM
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOINCNUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["LOINCNUM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LOINCTURKCETAMADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOINCTURKCETAMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["LOINCTURKCETAMADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LOINCLONGCOMMONNAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOINCLONGCOMMONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["LOINCLONGCOMMONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SUTKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["SUTKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SUTADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].AllPropertyDefs["SUTADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSLOINCSUTIliskisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSLOINCSUTIliskisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSLOINCSUTIliskisi_Class() : base() { }
        }

        public static BindingList<SKRSLOINCSUTIliskisi.GetSKRSLOINCSUTIliskisi_Class> GetSKRSLOINCSUTIliskisi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].QueryDefs["GetSKRSLOINCSUTIliskisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSLOINCSUTIliskisi.GetSKRSLOINCSUTIliskisi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSLOINCSUTIliskisi.GetSKRSLOINCSUTIliskisi_Class> GetSKRSLOINCSUTIliskisi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINCSUTILISKISI"].QueryDefs["GetSKRSLOINCSUTIliskisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSLOINCSUTIliskisi.GetSKRSLOINCSUTIliskisi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string LOINCNUM
        {
            get { return (string)this["LOINCNUM"]; }
            set { this["LOINCNUM"] = value; }
        }

        public string LOINCTURKCETAMADI
        {
            get { return (string)this["LOINCTURKCETAMADI"]; }
            set { this["LOINCTURKCETAMADI"] = value; }
        }

        public string LOINCLONGCOMMONNAME
        {
            get { return (string)this["LOINCLONGCOMMONNAME"]; }
            set { this["LOINCLONGCOMMONNAME"] = value; }
        }

        public string SUTKODU
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

        public string SUTADI
        {
            get { return (string)this["SUTADI"]; }
            set { this["SUTADI"] = value; }
        }

        protected SKRSLOINCSUTIliskisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSLOINCSUTIliskisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSLOINCSUTIliskisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSLOINCSUTIliskisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSLOINCSUTIliskisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSLOINCSUTILISKISI", dataRow) { }
        protected SKRSLOINCSUTIliskisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSLOINCSUTILISKISI", dataRow, isImported) { }
        public SKRSLOINCSUTIliskisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSLOINCSUTIliskisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSLOINCSUTIliskisi() : base() { }

    }
}