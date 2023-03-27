
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSLOINC")] 

    /// <summary>
    /// 39aef8d6-9b53-4b56-8c73-2f53b0599094
    /// </summary>
    public  partial class SKRSLOINC : BaseSKRSDefinition
    {
        public class SKRSLOINCList : TTObjectCollection<SKRSLOINC> { }
                    
        public class ChildSKRSLOINCCollection : TTObject.TTChildObjectCollection<SKRSLOINC>
        {
            public ChildSKRSLOINCCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSLOINCCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSLOINC_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string LOINCNUMARASI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOINCNUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["LOINCNUMARASI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LOINCSHORTNAMESil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOINCSHORTNAMESIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["LOINCSHORTNAMESIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LOINCCOMMONNAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOINCCOMMONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["LOINCCOMMONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LOINCTURKCEKARSILIGI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOINCTURKCEKARSILIGI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["LOINCTURKCEKARSILIGI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? CLASSTYPESil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLASSTYPESIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["CLASSTYPESIL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ASCCLASSTYPESil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASCCLASSTYPESIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["ASCCLASSTYPESIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GRUPNAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["GRUPNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string STATUSSil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUSSIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["STATUSSIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BILESEN
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BILESEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["BILESEN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OZELLIK
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZELLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["OZELLIK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ZAMANLAMA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ZAMANLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["ZAMANLAMA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MATERYAL
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERYAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["MATERYAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SKALA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKALA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["SKALA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string METOD
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["METOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["METOD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SUBMITTEDUNITSSil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMITTEDUNITSSIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["SUBMITTEDUNITSSIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EXAMPLEUNITSSil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMPLEUNITSSIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["EXAMPLEUNITSSIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TOPSil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPSIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["TOPSIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SFILGRUPSil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SFILGRUPSIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["SFILGRUPSIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GRUPADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRUPADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].AllPropertyDefs["GRUPADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSLOINC_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSLOINC_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSLOINC_Class() : base() { }
        }

        public static BindingList<SKRSLOINC.GetSKRSLOINC_Class> GetSKRSLOINC(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].QueryDefs["GetSKRSLOINC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSLOINC.GetSKRSLOINC_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSLOINC.GetSKRSLOINC_Class> GetSKRSLOINC(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].QueryDefs["GetSKRSLOINC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSLOINC.GetSKRSLOINC_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSLOINC> GetByLoincNum(TTObjectContext objectContext, string LOINCNUM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSLOINC"].QueryDefs["GetByLoincNum"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LOINCNUM", LOINCNUM);

            return ((ITTQuery)objectContext).QueryObjects<SKRSLOINC>(queryDef, paramList);
        }

        public string LOINCNUMARASI
        {
            get { return (string)this["LOINCNUMARASI"]; }
            set { this["LOINCNUMARASI"] = value; }
        }

        public string LOINCSHORTNAMESil
        {
            get { return (string)this["LOINCSHORTNAMESIL"]; }
            set { this["LOINCSHORTNAMESIL"] = value; }
        }

        public string LOINCCOMMONNAME
        {
            get { return (string)this["LOINCCOMMONNAME"]; }
            set { this["LOINCCOMMONNAME"] = value; }
        }

        public string LOINCTURKCEKARSILIGI
        {
            get { return (string)this["LOINCTURKCEKARSILIGI"]; }
            set { this["LOINCTURKCEKARSILIGI"] = value; }
        }

        public int? CLASSTYPESil
        {
            get { return (int?)this["CLASSTYPESIL"]; }
            set { this["CLASSTYPESIL"] = value; }
        }

        public string ASCCLASSTYPESil
        {
            get { return (string)this["ASCCLASSTYPESIL"]; }
            set { this["ASCCLASSTYPESIL"] = value; }
        }

        public string GRUPNAME
        {
            get { return (string)this["GRUPNAME"]; }
            set { this["GRUPNAME"] = value; }
        }

        public string STATUSSil
        {
            get { return (string)this["STATUSSIL"]; }
            set { this["STATUSSIL"] = value; }
        }

        public string BILESEN
        {
            get { return (string)this["BILESEN"]; }
            set { this["BILESEN"] = value; }
        }

        public string OZELLIK
        {
            get { return (string)this["OZELLIK"]; }
            set { this["OZELLIK"] = value; }
        }

        public string ZAMANLAMA
        {
            get { return (string)this["ZAMANLAMA"]; }
            set { this["ZAMANLAMA"] = value; }
        }

        public string MATERYAL
        {
            get { return (string)this["MATERYAL"]; }
            set { this["MATERYAL"] = value; }
        }

        public string SKALA
        {
            get { return (string)this["SKALA"]; }
            set { this["SKALA"] = value; }
        }

        public string METOD
        {
            get { return (string)this["METOD"]; }
            set { this["METOD"] = value; }
        }

        public string SUBMITTEDUNITSSil
        {
            get { return (string)this["SUBMITTEDUNITSSIL"]; }
            set { this["SUBMITTEDUNITSSIL"] = value; }
        }

        public string EXAMPLEUNITSSil
        {
            get { return (string)this["EXAMPLEUNITSSIL"]; }
            set { this["EXAMPLEUNITSSIL"] = value; }
        }

        public string TOPSil
        {
            get { return (string)this["TOPSIL"]; }
            set { this["TOPSIL"] = value; }
        }

        public string SFILGRUPSil
        {
            get { return (string)this["SFILGRUPSIL"]; }
            set { this["SFILGRUPSIL"] = value; }
        }

        public string GRUPADI
        {
            get { return (string)this["GRUPADI"]; }
            set { this["GRUPADI"] = value; }
        }

        protected SKRSLOINC(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSLOINC(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSLOINC(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSLOINC(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSLOINC(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSLOINC", dataRow) { }
        protected SKRSLOINC(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSLOINC", dataRow, isImported) { }
        public SKRSLOINC(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSLOINC(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSLOINC() : base() { }

    }
}