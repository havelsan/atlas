
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Technician")] 

    /// <summary>
    /// Teknisyen
    /// </summary>
    public  partial class Technician : TTObject
    {
        public class TechnicianList : TTObjectCollection<Technician> { }
                    
        public class ChildTechnicianCollection : TTObject.TTChildObjectCollection<Technician>
        {
            public ChildTechnicianCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTechnicianCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<Technician> GetAllTechnicians(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TECHNICIAN"].QueryDefs["GetAllTechnicians"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Technician>(queryDef, paramList);
        }

        public static BindingList<Technician> GetTechnicianById(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TECHNICIAN"].QueryDefs["GetTechnicianById"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<Technician>(queryDef, paramList);
        }

        public static BindingList<Technician> GetDentalTechnicians(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TECHNICIAN"].QueryDefs["GetDentalTechnicians"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Technician>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Teknisyen Tipi
    /// </summary>
        public DentalTechnicianTypeEnum? TechnicianType
        {
            get { return (DentalTechnicianTypeEnum?)(int?)this["TECHNICIANTYPE"]; }
            set { this["TECHNICIANTYPE"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTechniciansCollection()
        {
            _Technicians = new DentalLaboratoryProcedure.ChildDentalLaboratoryProcedureCollection(this, new Guid("a001a07b-7418-4ada-8bd6-f25066e34608"));
            ((ITTChildObjectCollection)_Technicians).GetChildren();
        }

        protected DentalLaboratoryProcedure.ChildDentalLaboratoryProcedureCollection _Technicians = null;
        public DentalLaboratoryProcedure.ChildDentalLaboratoryProcedureCollection Technicians
        {
            get
            {
                if (_Technicians == null)
                    CreateTechniciansCollection();
                return _Technicians;
            }
        }

        protected Technician(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Technician(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Technician(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Technician(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Technician(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TECHNICIAN", dataRow) { }
        protected Technician(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TECHNICIAN", dataRow, isImported) { }
        public Technician(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Technician(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Technician() : base() { }

    }
}