
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSTETKIKISTEMDURUMUDEGERLENDIRME")] 

    /// <summary>
    /// 6359a2ce-39f5-42f8-99ec-f1d4c0874672
    /// </summary>
    public  partial class SKRSTETKIKISTEMDURUMUDEGERLENDIRME : BaseSKRSDefinition
    {
        public class SKRSTETKIKISTEMDURUMUDEGERLENDIRMEList : TTObjectCollection<SKRSTETKIKISTEMDURUMUDEGERLENDIRME> { }
                    
        public class ChildSKRSTETKIKISTEMDURUMUDEGERLENDIRMECollection : TTObject.TTChildObjectCollection<SKRSTETKIKISTEMDURUMUDEGERLENDIRME>
        {
            public ChildSKRSTETKIKISTEMDURUMUDEGERLENDIRMECollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSTETKIKISTEMDURUMUDEGERLENDIRMECollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].AllPropertyDefs["KODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].AllPropertyDefs["KODTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME_Class() : base() { }
        }

        public static BindingList<SKRSTETKIKISTEMDURUMUDEGERLENDIRME.GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME_Class> GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].QueryDefs["GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTETKIKISTEMDURUMUDEGERLENDIRME.GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSTETKIKISTEMDURUMUDEGERLENDIRME.GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME_Class> GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSTETKIKISTEMDURUMUDEGERLENDIRME"].QueryDefs["GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSTETKIKISTEMDURUMUDEGERLENDIRME.GetSKRSTETKIKISTEMDURUMUDEGERLENDIRME_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public string KODU
        {
            get { return (string)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public string KODTIPIADI
        {
            get { return (string)this["KODTIPIADI"]; }
            set { this["KODTIPIADI"] = value; }
        }

        protected SKRSTETKIKISTEMDURUMUDEGERLENDIRME(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSTETKIKISTEMDURUMUDEGERLENDIRME(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSTETKIKISTEMDURUMUDEGERLENDIRME(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSTETKIKISTEMDURUMUDEGERLENDIRME(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSTETKIKISTEMDURUMUDEGERLENDIRME(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSTETKIKISTEMDURUMUDEGERLENDIRME", dataRow) { }
        protected SKRSTETKIKISTEMDURUMUDEGERLENDIRME(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSTETKIKISTEMDURUMUDEGERLENDIRME", dataRow, isImported) { }
        public SKRSTETKIKISTEMDURUMUDEGERLENDIRME(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSTETKIKISTEMDURUMUDEGERLENDIRME(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSTETKIKISTEMDURUMUDEGERLENDIRME() : base() { }

    }
}