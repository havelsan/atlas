
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPMaster")] 

    public  partial class DPMaster : TTObject
    {
        public class DPMasterList : TTObjectCollection<DPMaster> { }
                    
        public class ChildDPMasterCollection : TTObject.TTChildObjectCollection<DPMaster>
        {
            public ChildDPMasterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPMasterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<DPMaster> GetMasterByTermAndDoctor(TTObjectContext objectContext, Guid TERM, Guid DOCTOR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPMASTER"].QueryDefs["GetMasterByTermAndDoctor"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERM", TERM);
            paramList.Add("DOCTOR", DOCTOR);

            return ((ITTQuery)objectContext).QueryObjects<DPMaster>(queryDef, paramList);
        }

    /// <summary>
    /// Sorgulama Tarihi
    /// </summary>
        public DateTime? ExecDate
        {
            get { return (DateTime?)this["EXECDATE"]; }
            set { this["EXECDATE"] = value; }
        }

        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DoctorPerformanceTerm Term
        {
            get { return (DoctorPerformanceTerm)((ITTObject)this).GetParent("TERM"); }
            set { this["TERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDPDetailsCollection()
        {
            _DPDetails = new DPDetail.ChildDPDetailCollection(this, new Guid("c6d60e6c-08de-4102-bbf7-aa3cd300b35e"));
            ((ITTChildObjectCollection)_DPDetails).GetChildren();
        }

        protected DPDetail.ChildDPDetailCollection _DPDetails = null;
        public DPDetail.ChildDPDetailCollection DPDetails
        {
            get
            {
                if (_DPDetails == null)
                    CreateDPDetailsCollection();
                return _DPDetails;
            }
        }

        protected DPMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPMaster(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPMaster(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPMaster(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPMASTER", dataRow) { }
        protected DPMaster(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPMASTER", dataRow, isImported) { }
        public DPMaster(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPMaster(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPMaster() : base() { }

    }
}