
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugATC")] 

    public  partial class DrugATC : TerminologyManagerDef
    {
        public class DrugATCList : TTObjectCollection<DrugATC> { }
                    
        public class ChildDrugATCCollection : TTObject.TTChildObjectCollection<DrugATC>
        {
            public ChildDrugATCCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugATCCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetDrugATC_Class : TTReportNqlObject 
        {
            public Guid? ATC
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ATC"]);
                }
            }

            public Guid? Ilac
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ILAC"]);
                }
            }

            public Object Mevcut
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEVCUT"]);
                }
            }

            public Object Tarih
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TARIH"]);
                }
            }

            public OLAP_GetDrugATC_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDrugATC_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDrugATC_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetDrugATCDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ATC
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ATC"]);
                }
            }

            public Guid? DrugDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

            public OLAP_GetDrugATCDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDrugATCDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDrugATCDef_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugATCListRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Atccode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATCCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ATC"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Atcname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ATC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Drugname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Drugbarcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGBARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetDrugATCListRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugATCListRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugATCListRQ_Class() : base() { }
        }

        public static BindingList<DrugATC> GetDrugATCbyLastupdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGATC"].QueryDefs["GetDrugATCbyLastupdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DrugATC>(queryDef, paramList);
        }

        public static BindingList<DrugATC.OLAP_GetDrugATC_Class> OLAP_GetDrugATC(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGATC"].QueryDefs["OLAP_GetDrugATC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugATC.OLAP_GetDrugATC_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugATC.OLAP_GetDrugATC_Class> OLAP_GetDrugATC(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGATC"].QueryDefs["OLAP_GetDrugATC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugATC.OLAP_GetDrugATC_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugATC.OLAP_GetDrugATCDef_Class> OLAP_GetDrugATCDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGATC"].QueryDefs["OLAP_GetDrugATCDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugATC.OLAP_GetDrugATCDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugATC.OLAP_GetDrugATCDef_Class> OLAP_GetDrugATCDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGATC"].QueryDefs["OLAP_GetDrugATCDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugATC.OLAP_GetDrugATCDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugATC.GetDrugATCListRQ_Class> GetDrugATCListRQ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGATC"].QueryDefs["GetDrugATCListRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugATC.GetDrugATCListRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugATC.GetDrugATCListRQ_Class> GetDrugATCListRQ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGATC"].QueryDefs["GetDrugATCListRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugATC.GetDrugATCListRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public Guid? OldDrugDefinition
        {
            get { return (Guid?)this["OLDDRUGDEFINITION"]; }
            set { this["OLDDRUGDEFINITION"] = value; }
        }

        public ATC ATC
        {
            get { return (ATC)((ITTObject)this).GetParent("ATC"); }
            set { this["ATC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugATC(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugATC(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugATC(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugATC(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugATC(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGATC", dataRow) { }
        protected DrugATC(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGATC", dataRow, isImported) { }
        public DrugATC(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugATC(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugATC() : base() { }

    }
}