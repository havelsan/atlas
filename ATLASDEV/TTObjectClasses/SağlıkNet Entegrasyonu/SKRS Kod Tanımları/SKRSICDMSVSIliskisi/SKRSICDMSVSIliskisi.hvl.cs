
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSICDMSVSIliskisi")] 

    /// <summary>
    /// a7de45ea-4792-4dda-8b43-3f26e856f62b
    /// </summary>
    public  partial class SKRSICDMSVSIliskisi : BaseSKRSDefinition
    {
        public class SKRSICDMSVSIliskisiList : TTObjectCollection<SKRSICDMSVSIliskisi> { }
                    
        public class ChildSKRSICDMSVSIliskisiCollection : TTObject.TTChildObjectCollection<SKRSICDMSVSIliskisi>
        {
            public ChildSKRSICDMSVSIliskisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSICDMSVSIliskisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSICDMSVSIliskisi_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["DEFAULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["AKTIF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["OLUSTURULMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["GUNCELLENMETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["PASIFEALINMATARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["GUNCELLEMETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ICDKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICDKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["ICDKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MSVSKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MSVSKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["MSVSKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MSVSADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MSVSADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["MSVSADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CINSIYETKODU
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYETKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["CINSIYETKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CINSIYETADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYETADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["CINSIYETADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? GUNCELLENMETARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUNCELLENMETARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["GUNCELLENMETARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OLUSTURULMATARIHI1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURULMATARIHI1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].AllPropertyDefs["OLUSTURULMATARIHI1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSICDMSVSIliskisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSICDMSVSIliskisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSICDMSVSIliskisi_Class() : base() { }
        }

        public static BindingList<SKRSICDMSVSIliskisi.GetSKRSICDMSVSIliskisi_Class> GetSKRSICDMSVSIliskisi(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].QueryDefs["GetSKRSICDMSVSIliskisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSICDMSVSIliskisi.GetSKRSICDMSVSIliskisi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSICDMSVSIliskisi.GetSKRSICDMSVSIliskisi_Class> GetSKRSICDMSVSIliskisi(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].QueryDefs["GetSKRSICDMSVSIliskisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSICDMSVSIliskisi.GetSKRSICDMSVSIliskisi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSICDMSVSIliskisi> GetSkrsICDMSVSIliskisiByICDKODU(TTObjectContext objectContext, string ICDKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSICDMSVSILISKISI"].QueryDefs["GetSkrsICDMSVSIliskisiByICDKODU"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ICDKODU", ICDKODU);

            return ((ITTQuery)objectContext).QueryObjects<SKRSICDMSVSIliskisi>(queryDef, paramList);
        }

        public string ICDKODU
        {
            get { return (string)this["ICDKODU"]; }
            set { this["ICDKODU"] = value; }
        }

        public int? MSVSKODU
        {
            get { return (int?)this["MSVSKODU"]; }
            set { this["MSVSKODU"] = value; }
        }

        public string MSVSADI
        {
            get { return (string)this["MSVSADI"]; }
            set { this["MSVSADI"] = value; }
        }

        public string CINSIYETKODU
        {
            get { return (string)this["CINSIYETKODU"]; }
            set { this["CINSIYETKODU"] = value; }
        }

        public string CINSIYETADI
        {
            get { return (string)this["CINSIYETADI"]; }
            set { this["CINSIYETADI"] = value; }
        }

        public DateTime? GUNCELLENMETARIHI1
        {
            get { return (DateTime?)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        public DateTime? OLUSTURULMATARIHI1
        {
            get { return (DateTime?)this["OLUSTURULMATARIHI1"]; }
            set { this["OLUSTURULMATARIHI1"] = value; }
        }

        protected SKRSICDMSVSIliskisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSICDMSVSIliskisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSICDMSVSIliskisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSICDMSVSIliskisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSICDMSVSIliskisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSICDMSVSILISKISI", dataRow) { }
        protected SKRSICDMSVSIliskisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSICDMSVSILISKISI", dataRow, isImported) { }
        public SKRSICDMSVSIliskisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSICDMSVSIliskisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSICDMSVSIliskisi() : base() { }

    }
}