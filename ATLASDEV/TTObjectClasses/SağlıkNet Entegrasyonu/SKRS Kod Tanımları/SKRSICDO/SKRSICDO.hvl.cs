
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSICDO")] 

    /// <summary>
    /// 7b7a4434-2295-4512-91e7-d72c66ddfbb9
    /// </summary>
    public  partial class SKRSICDO : BaseSKRSDefinition
    {
        public class SKRSICDOList : TTObjectCollection<SKRSICDO> { }
                    
        public class ChildSKRSICDOCollection : TTObject.TTChildObjectCollection<SKRSICDO>
        {
            public ChildSKRSICDOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSICDOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSICDO_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? KOD
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["KOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TOPOGRAFI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPOGRAFI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["TOPOGRAFI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string YERLESIMBILGISI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YERLESIMBILGISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["YERLESIMBILGISI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? HISTOLOJIKOD
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HISTOLOJIKOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["HISTOLOJIKOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string HISTOLOJIACIKLAMA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HISTOLOJIACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["HISTOLOJIACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DAVRANISKOD
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAVRANISKOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["DAVRANISKOD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DAVRANISKODTANIM
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAVRANISKODTANIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["DAVRANISKODTANIM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DAVRANISKODACIKLAMA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAVRANISKODACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].AllPropertyDefs["DAVRANISKODACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSICDO_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSICDO_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSICDO_Class() : base() { }
        }

        public static BindingList<SKRSICDO.GetSKRSICDO_Class> GetSKRSICDO(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].QueryDefs["GetSKRSICDO"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSICDO.GetSKRSICDO_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSICDO.GetSKRSICDO_Class> GetSKRSICDO(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSICDO"].QueryDefs["GetSKRSICDO"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSICDO.GetSKRSICDO_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? KOD
        {
            get { return (int?)this["KOD"]; }
            set { this["KOD"] = value; }
        }

        public string TOPOGRAFI
        {
            get { return (string)this["TOPOGRAFI"]; }
            set { this["TOPOGRAFI"] = value; }
        }

        public string YERLESIMBILGISI
        {
            get { return (string)this["YERLESIMBILGISI"]; }
            set { this["YERLESIMBILGISI"] = value; }
        }

        public int? HISTOLOJIKOD
        {
            get { return (int?)this["HISTOLOJIKOD"]; }
            set { this["HISTOLOJIKOD"] = value; }
        }

        public string HISTOLOJIACIKLAMA
        {
            get { return (string)this["HISTOLOJIACIKLAMA"]; }
            set { this["HISTOLOJIACIKLAMA"] = value; }
        }

        public string DAVRANISKOD
        {
            get { return (string)this["DAVRANISKOD"]; }
            set { this["DAVRANISKOD"] = value; }
        }

        public string DAVRANISKODTANIM
        {
            get { return (string)this["DAVRANISKODTANIM"]; }
            set { this["DAVRANISKODTANIM"] = value; }
        }

        public string DAVRANISKODACIKLAMA
        {
            get { return (string)this["DAVRANISKODACIKLAMA"]; }
            set { this["DAVRANISKODACIKLAMA"] = value; }
        }

        protected SKRSICDO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSICDO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSICDO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSICDO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSICDO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSICDO", dataRow) { }
        protected SKRSICDO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSICDO", dataRow, isImported) { }
        public SKRSICDO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSICDO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSICDO() : base() { }

    }
}