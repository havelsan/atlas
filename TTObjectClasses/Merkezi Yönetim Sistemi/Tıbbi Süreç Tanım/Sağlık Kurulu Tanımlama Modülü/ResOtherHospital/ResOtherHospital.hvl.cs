
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResOtherHospital")] 

    /// <summary>
    /// Diğer XXXXXX
    /// </summary>
    public  partial class ResOtherHospital : ResSection
    {
        public class ResOtherHospitalList : TTObjectCollection<ResOtherHospital> { }
                    
        public class ChildResOtherHospitalCollection : TTObject.TTChildObjectCollection<ResOtherHospital>
        {
            public ChildResOtherHospitalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResOtherHospitalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResOtherHospital_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public OLAP_ResOtherHospital_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResOtherHospital_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResOtherHospital_Class() : base() { }
        }

        public static BindingList<ResOtherHospital> GetBySite(TTObjectContext objectContext, Guid SITE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].QueryDefs["GetBySite"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SITE", SITE);

            return ((ITTQuery)objectContext).QueryObjects<ResOtherHospital>(queryDef, paramList);
        }

        public static BindingList<ResOtherHospital.OLAP_ResOtherHospital_Class> OLAP_ResOtherHospital(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].QueryDefs["OLAP_ResOtherHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResOtherHospital.OLAP_ResOtherHospital_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResOtherHospital.OLAP_ResOtherHospital_Class> OLAP_ResOtherHospital(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].QueryDefs["OLAP_ResOtherHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResOtherHospital.OLAP_ResOtherHospital_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResOtherHospital> GetResOtherHospitalByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].QueryDefs["GetResOtherHospitalByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ResOtherHospital>(queryDef, paramList);
        }

        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReferableHospitalCollection()
        {
            _ReferableHospital = new ReferableHospital.ChildReferableHospitalCollection(this, new Guid("5a38c346-bc08-4dc8-8feb-e69bad1dd13c"));
            ((ITTChildObjectCollection)_ReferableHospital).GetChildren();
        }

        protected ReferableHospital.ChildReferableHospitalCollection _ReferableHospital = null;
    /// <summary>
    /// Child collection for Havale Edilebilir XXXXXX
    /// </summary>
        public ReferableHospital.ChildReferableHospitalCollection ReferableHospital
        {
            get
            {
                if (_ReferableHospital == null)
                    CreateReferableHospitalCollection();
                return _ReferableHospital;
            }
        }

        protected ResOtherHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResOtherHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResOtherHospital(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResOtherHospital(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResOtherHospital(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESOTHERHOSPITAL", dataRow) { }
        protected ResOtherHospital(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESOTHERHOSPITAL", dataRow, isImported) { }
        protected ResOtherHospital(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResOtherHospital(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResOtherHospital() : base() { }

    }
}