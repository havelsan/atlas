
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSHEMOGLOBINOPATITARAMATESTISONUCU")] 

    /// <summary>
    /// 3f621539-c978-4208-b7ff-8c972064a08b
    /// </summary>
    public  partial class SKRSHEMOGLOBINOPATITARAMATESTISONUCU : BaseSKRSDefinition
    {
        public class SKRSHEMOGLOBINOPATITARAMATESTISONUCUList : TTObjectCollection<SKRSHEMOGLOBINOPATITARAMATESTISONUCU> { }
                    
        public class ChildSKRSHEMOGLOBINOPATITARAMATESTISONUCUCollection : TTObject.TTChildObjectCollection<SKRSHEMOGLOBINOPATITARAMATESTISONUCU>
        {
            public ChildSKRSHEMOGLOBINOPATITARAMATESTISONUCUCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSHEMOGLOBINOPATITARAMATESTISONUCUCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string KODTIPIADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODTIPIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].AllPropertyDefs["KODTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].AllPropertyDefs["ADI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU_Class() : base() { }
        }

        public static BindingList<SKRSHEMOGLOBINOPATITARAMATESTISONUCU.GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU_Class> GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].QueryDefs["GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSHEMOGLOBINOPATITARAMATESTISONUCU.GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSHEMOGLOBINOPATITARAMATESTISONUCU.GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU_Class> GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSHEMOGLOBINOPATITARAMATESTISONUCU"].QueryDefs["GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSHEMOGLOBINOPATITARAMATESTISONUCU.GetSKRSHEMOGLOBINOPATITARAMATESTISONUCU_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string KODTIPIADI
        {
            get { return (string)this["KODTIPIADI"]; }
            set { this["KODTIPIADI"] = value; }
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

        protected SKRSHEMOGLOBINOPATITARAMATESTISONUCU(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSHEMOGLOBINOPATITARAMATESTISONUCU(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSHEMOGLOBINOPATITARAMATESTISONUCU(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSHEMOGLOBINOPATITARAMATESTISONUCU(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSHEMOGLOBINOPATITARAMATESTISONUCU(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSHEMOGLOBINOPATITARAMATESTISONUCU", dataRow) { }
        protected SKRSHEMOGLOBINOPATITARAMATESTISONUCU(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSHEMOGLOBINOPATITARAMATESTISONUCU", dataRow, isImported) { }
        public SKRSHEMOGLOBINOPATITARAMATESTISONUCU(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSHEMOGLOBINOPATITARAMATESTISONUCU(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSHEMOGLOBINOPATITARAMATESTISONUCU() : base() { }

    }
}