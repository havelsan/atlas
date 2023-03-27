
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSICDOYERLESIMYERI")] 

    /// <summary>
    /// fc24f548-c383-4855-be0b-0f1d23599bba
    /// </summary>
    public  partial class SKRSICDOYERLESIMYERI : BaseSKRSDefinition
    {
        public class SKRSICDOYERLESIMYERIList : TTObjectCollection<SKRSICDOYERLESIMYERI> { }
                    
        public class ChildSKRSICDOYERLESIMYERICollection : TTObject.TTChildObjectCollection<SKRSICDOYERLESIMYERI>
        {
            public ChildSKRSICDOYERLESIMYERICollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSICDOYERLESIMYERICollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSICDOYERLESIMYERI_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? SKRSKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKRSKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["SKRSKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string TOPOGRAFIKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPOGRAFIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["TOPOGRAFIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KODTANIMI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODTANIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["KODTANIMI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KODACIKLAMA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].AllPropertyDefs["KODACIKLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSICDOYERLESIMYERI_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSICDOYERLESIMYERI_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSICDOYERLESIMYERI_Class() : base() { }
        }

        public static BindingList<SKRSICDOYERLESIMYERI.GetSKRSICDOYERLESIMYERI_Class> GetSKRSICDOYERLESIMYERI(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].QueryDefs["GetSKRSICDOYERLESIMYERI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSICDOYERLESIMYERI.GetSKRSICDOYERLESIMYERI_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSICDOYERLESIMYERI.GetSKRSICDOYERLESIMYERI_Class> GetSKRSICDOYERLESIMYERI(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSICDOYERLESIMYERI"].QueryDefs["GetSKRSICDOYERLESIMYERI"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSICDOYERLESIMYERI.GetSKRSICDOYERLESIMYERI_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? SKRSKODU
        {
            get { return (int?)this["SKRSKODU"]; }
            set { this["SKRSKODU"] = value; }
        }

        public string TOPOGRAFIKODU
        {
            get { return (string)this["TOPOGRAFIKODU"]; }
            set { this["TOPOGRAFIKODU"] = value; }
        }

        public string KODTANIMI
        {
            get { return (string)this["KODTANIMI"]; }
            set { this["KODTANIMI"] = value; }
        }

        public string KODACIKLAMA
        {
            get { return (string)this["KODACIKLAMA"]; }
            set { this["KODACIKLAMA"] = value; }
        }

        protected SKRSICDOYERLESIMYERI(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSICDOYERLESIMYERI(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSICDOYERLESIMYERI(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSICDOYERLESIMYERI(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSICDOYERLESIMYERI(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSICDOYERLESIMYERI", dataRow) { }
        protected SKRSICDOYERLESIMYERI(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSICDOYERLESIMYERI", dataRow, isImported) { }
        public SKRSICDOYERLESIMYERI(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSICDOYERLESIMYERI(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSICDOYERLESIMYERI() : base() { }

    }
}