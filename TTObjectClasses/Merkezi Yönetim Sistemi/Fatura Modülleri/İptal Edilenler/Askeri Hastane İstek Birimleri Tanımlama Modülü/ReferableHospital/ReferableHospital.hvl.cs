
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReferableHospital")] 

    public  partial class ReferableHospital : TerminologyManagerDef
    {
        public class ReferableHospitalList : TTObjectCollection<ReferableHospital> { }
                    
        public class ChildReferableHospitalCollection : TTObject.TTChildObjectCollection<ReferableHospital>
        {
            public ChildReferableHospitalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReferableHospitalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetReferableHospital_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public GetReferableHospital_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReferableHospital_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReferableHospital_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByResHospitalAndAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetByResHospitalAndAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByResHospitalAndAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByResHospitalAndAction_Class() : base() { }
        }

        public static BindingList<ReferableHospital.GetReferableHospital_Class> GetReferableHospital(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLEHOSPITAL"].QueryDefs["GetReferableHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReferableHospital.GetReferableHospital_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReferableHospital.GetReferableHospital_Class> GetReferableHospital(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLEHOSPITAL"].QueryDefs["GetReferableHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReferableHospital.GetReferableHospital_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReferableHospital.GetByResHospitalAndAction_Class> GetByResHospitalAndAction(string RESOTHERHOSPITAL, ReferableActionEnum REFERABLEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLEHOSPITAL"].QueryDefs["GetByResHospitalAndAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOTHERHOSPITAL", RESOTHERHOSPITAL);
            paramList.Add("REFERABLEACTION", (int)REFERABLEACTION);

            return TTReportNqlObject.QueryObjects<ReferableHospital.GetByResHospitalAndAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReferableHospital.GetByResHospitalAndAction_Class> GetByResHospitalAndAction(TTObjectContext objectContext, string RESOTHERHOSPITAL, ReferableActionEnum REFERABLEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLEHOSPITAL"].QueryDefs["GetByResHospitalAndAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOTHERHOSPITAL", RESOTHERHOSPITAL);
            paramList.Add("REFERABLEACTION", (int)REFERABLEACTION);

            return TTReportNqlObject.QueryObjects<ReferableHospital.GetByResHospitalAndAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReferableHospital> GetByResOtherHospital(TTObjectContext objectContext, Guid RESOTHERHOSPITAL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLEHOSPITAL"].QueryDefs["GetByResOtherHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOTHERHOSPITAL", RESOTHERHOSPITAL);

            return ((ITTQuery)objectContext).QueryObjects<ReferableHospital>(queryDef, paramList);
        }

        public static BindingList<ReferableHospital> GetByResourceObjectID(TTObjectContext objectContext, string RESOURCEOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLEHOSPITAL"].QueryDefs["GetByResourceObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEOBJECTID", RESOURCEOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ReferableHospital>(queryDef, paramList);
        }

    /// <summary>
    /// En Son Güncelleyen Saha
    /// </summary>
        public Guid? LastUpdateSiteGuid
        {
            get { return (Guid?)this["LASTUPDATESITEGUID"]; }
            set { this["LASTUPDATESITEGUID"] = value; }
        }

    /// <summary>
    /// En Son Güncelleyen Saha(Merkez hariç)
    /// </summary>
        public Guid? LastUpdateRealSiteGuid
        {
            get { return (Guid?)this["LASTUPDATEREALSITEGUID"]; }
            set { this["LASTUPDATEREALSITEGUID"] = value; }
        }

    /// <summary>
    /// Havale Edilebilen XXXXXXler
    /// </summary>
        public ReferableResourceDefinition ReferableResourceDefinition
        {
            get { return (ReferableResourceDefinition)((ITTObject)this).GetParent("REFERABLERESOURCEDEFINITION"); }
            set { this["REFERABLERESOURCEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Havale Edilebilir XXXXXX
    /// </summary>
        public ResOtherHospital ResOtherHospital
        {
            get { return (ResOtherHospital)((ITTObject)this).GetParent("RESOTHERHOSPITAL"); }
            set { this["RESOTHERHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReferableResourcesCollection()
        {
            _ReferableResources = new ReferableResource.ChildReferableResourceCollection(this, new Guid("70fe1179-b5ec-4220-adb1-14467af360d2"));
            ((ITTChildObjectCollection)_ReferableResources).GetChildren();
        }

        protected ReferableResource.ChildReferableResourceCollection _ReferableResources = null;
    /// <summary>
    /// Child collection for Havale Edilebilen Kaynaklar
    /// </summary>
        public ReferableResource.ChildReferableResourceCollection ReferableResources
        {
            get
            {
                if (_ReferableResources == null)
                    CreateReferableResourcesCollection();
                return _ReferableResources;
            }
        }

        protected ReferableHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReferableHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReferableHospital(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReferableHospital(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReferableHospital(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REFERABLEHOSPITAL", dataRow) { }
        protected ReferableHospital(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REFERABLEHOSPITAL", dataRow, isImported) { }
        public ReferableHospital(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReferableHospital(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReferableHospital() : base() { }

    }
}