
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CozgerSpecReqLevel")] 

    /// <summary>
    /// Çözger Special Requirement Level (Özel Gereksinim Seviyesi)
    /// </summary>
    public  partial class CozgerSpecReqLevel : TerminologyManagerDef
    {
        public class CozgerSpecReqLevelList : TTObjectCollection<CozgerSpecReqLevel> { }
                    
        public class ChildCozgerSpecReqLevelCollection : TTObject.TTChildObjectCollection<CozgerSpecReqLevel>
        {
            public ChildCozgerSpecReqLevelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCozgerSpecReqLevelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCozgerSpecReqLevels_Class : TTReportNqlObject 
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

            public string Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COZGERSPECREQLEVEL"].AllPropertyDefs["ID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COZGERSPECREQLEVEL"].AllPropertyDefs["ACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? GereksinimYuzdeBaslangic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GEREKSINIMYUZDEBASLANGIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COZGERSPECREQLEVEL"].AllPropertyDefs["GEREKSINIMYUZDEBASLANGIC"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? GereksinimYuzdeBitis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GEREKSINIMYUZDEBITIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COZGERSPECREQLEVEL"].AllPropertyDefs["GEREKSINIMYUZDEBITIS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetCozgerSpecReqLevels_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCozgerSpecReqLevels_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCozgerSpecReqLevels_Class() : base() { }
        }

        public static BindingList<CozgerSpecReqLevel.GetCozgerSpecReqLevels_Class> GetCozgerSpecReqLevels(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COZGERSPECREQLEVEL"].QueryDefs["GetCozgerSpecReqLevels"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CozgerSpecReqLevel.GetCozgerSpecReqLevels_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CozgerSpecReqLevel.GetCozgerSpecReqLevels_Class> GetCozgerSpecReqLevels(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COZGERSPECREQLEVEL"].QueryDefs["GetCozgerSpecReqLevels"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CozgerSpecReqLevel.GetCozgerSpecReqLevels_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CozgerSpecReqLevel> GetCozgerSpecReqLevelObjs(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COZGERSPECREQLEVEL"].QueryDefs["GetCozgerSpecReqLevelObjs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<CozgerSpecReqLevel>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Id
    /// </summary>
        public string Id
        {
            get { return (string)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

    /// <summary>
    /// Gereksinim Başlangıç Yüzdesi
    /// </summary>
        public int? GereksinimYuzdeBaslangic
        {
            get { return (int?)this["GEREKSINIMYUZDEBASLANGIC"]; }
            set { this["GEREKSINIMYUZDEBASLANGIC"] = value; }
        }

    /// <summary>
    /// Gereksinim Bitiş Yüzdesi
    /// </summary>
        public int? GereksinimYuzdeBitis
        {
            get { return (int?)this["GEREKSINIMYUZDEBITIS"]; }
            set { this["GEREKSINIMYUZDEBITIS"] = value; }
        }

        protected CozgerSpecReqLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CozgerSpecReqLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CozgerSpecReqLevel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CozgerSpecReqLevel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CozgerSpecReqLevel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COZGERSPECREQLEVEL", dataRow) { }
        protected CozgerSpecReqLevel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COZGERSPECREQLEVEL", dataRow, isImported) { }
        public CozgerSpecReqLevel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CozgerSpecReqLevel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CozgerSpecReqLevel() : base() { }

    }
}