
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DCAction")] 

    /// <summary>
    /// Demirbaş Çizelgesi
    /// </summary>
    public  partial class DCAction : TTObject
    {
        public class DCActionList : TTObjectCollection<DCAction> { }
                    
        public class ChildDCActionCollection : TTObject.TTChildObjectCollection<DCAction>
        {
            public ChildDCActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDCActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DCActionReportQuery_Class : TTReportNqlObject 
        {
            public string SeriNumarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERINUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["SERINUMARASI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Marka
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARKA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["MARKA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Guc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["GUC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Frekans
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREKANS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["FREKANS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Voltaj
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOLTAJ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["VOLTAJ"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GarantiAciklamasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GARANTIACIKLAMASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["GARANTIACIKLAMASI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? GarantiBaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GARANTIBASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["GARANTIBASLANGICTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GarantiBitisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GARANTIBITISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["GARANTIBITISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SonKalibrasyonTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONKALIBRASYONTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["SONKALIBRASYONTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SonBakimTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SONBAKIMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].AllPropertyDefs["SONBAKIMTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DCActionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DCActionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DCActionReportQuery_Class() : base() { }
        }

        public static BindingList<DCAction.DCActionReportQuery_Class> DCActionReportQuery(string STCACTIONID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].QueryDefs["DCActionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STCACTIONID", STCACTIONID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<DCAction.DCActionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DCAction.DCActionReportQuery_Class> DCActionReportQuery(TTObjectContext objectContext, string STCACTIONID, string STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DCACTION"].QueryDefs["DCActionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STCACTIONID", STCACTIONID);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<DCAction.DCActionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Demirbaş Numarası
    /// </summary>
        public string FixedAssetNO
        {
            get { return (string)this["FIXEDASSETNO"]; }
            set { this["FIXEDASSETNO"] = value; }
        }

        public string Frekans
        {
            get { return (string)this["FREKANS"]; }
            set { this["FREKANS"] = value; }
        }

        public string GarantiAciklamasi
        {
            get { return (string)this["GARANTIACIKLAMASI"]; }
            set { this["GARANTIACIKLAMASI"] = value; }
        }

        public DateTime? GarantiBaslangicTarihi
        {
            get { return (DateTime?)this["GARANTIBASLANGICTARIHI"]; }
            set { this["GARANTIBASLANGICTARIHI"] = value; }
        }

        public DateTime? GarantiBitisTarihi
        {
            get { return (DateTime?)this["GARANTIBITISTARIHI"]; }
            set { this["GARANTIBITISTARIHI"] = value; }
        }

        public string Guc
        {
            get { return (string)this["GUC"]; }
            set { this["GUC"] = value; }
        }

        public DateTime? ImalTarihi
        {
            get { return (DateTime?)this["IMALTARIHI"]; }
            set { this["IMALTARIHI"] = value; }
        }

        public string Marka
        {
            get { return (string)this["MARKA"]; }
            set { this["MARKA"] = value; }
        }

        public string Model
        {
            get { return (string)this["MODEL"]; }
            set { this["MODEL"] = value; }
        }

        public DateTime? SonBakimTarihi
        {
            get { return (DateTime?)this["SONBAKIMTARIHI"]; }
            set { this["SONBAKIMTARIHI"] = value; }
        }

        public DateTime? SonKalibrasyonTarihi
        {
            get { return (DateTime?)this["SONKALIBRASYONTARIHI"]; }
            set { this["SONKALIBRASYONTARIHI"] = value; }
        }

        public string Voltaj
        {
            get { return (string)this["VOLTAJ"]; }
            set { this["VOLTAJ"] = value; }
        }

        public string SeriNumarasi
        {
            get { return (string)this["SERINUMARASI"]; }
            set { this["SERINUMARASI"] = value; }
        }

        public STCAction STCAction
        {
            get { return (STCAction)((ITTObject)this).GetParent("STCACTION"); }
            set { this["STCACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DCAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DCAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DCAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DCAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DCAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DCACTION", dataRow) { }
        protected DCAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DCACTION", dataRow, isImported) { }
        public DCAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DCAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DCAction() : base() { }

    }
}