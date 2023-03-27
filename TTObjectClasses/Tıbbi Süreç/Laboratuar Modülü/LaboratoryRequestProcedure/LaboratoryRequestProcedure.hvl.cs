
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryRequestProcedure")] 

    public  partial class LaboratoryRequestProcedure : TTObject
    {
        public class LaboratoryRequestProcedureList : TTObjectCollection<LaboratoryRequestProcedure> { }
                    
        public class ChildLaboratoryRequestProcedureCollection : TTObject.TTChildObjectCollection<LaboratoryRequestProcedure>
        {
            public ChildLaboratoryRequestProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryRequestProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sonuç Tarihi
    /// </summary>
        public DateTime? ResultDate
        {
            get { return (DateTime?)this["RESULTDATE"]; }
            set { this["RESULTDATE"] = value; }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

        public LaboratoryRequestProcedure RequestProcedure
        {
            get { return (LaboratoryRequestProcedure)((ITTObject)this).GetParent("REQUESTPROCEDURE"); }
            set { this["REQUESTPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public LaboratoryProcedureResult LaboratoryProcedureResult
        {
            get { return (LaboratoryProcedureResult)((ITTObject)this).GetParent("LABORATORYPROCEDURERESULT"); }
            set { this["LABORATORYPROCEDURERESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResLaboratoryDepartment ProcedureDepartment
        {
            get { return (ResLaboratoryDepartment)((ITTObject)this).GetParent("PROCEDUREDEPARTMENT"); }
            set { this["PROCEDUREDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public LaboratoryTestDefinition ProcedureObject
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public LaboratoryRequest LaboratoryRequest
        {
            get { return (LaboratoryRequest)((ITTObject)this).GetParent("LABORATORYREQUEST"); }
            set { this["LABORATORYREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubProceduresCollection()
        {
            _SubProcedures = new LaboratoryRequestProcedure.ChildLaboratoryRequestProcedureCollection(this, new Guid("c1a82235-bd71-45d1-b868-1bc9ffa8964d"));
            ((ITTChildObjectCollection)_SubProcedures).GetChildren();
        }

        protected LaboratoryRequestProcedure.ChildLaboratoryRequestProcedureCollection _SubProcedures = null;
        public LaboratoryRequestProcedure.ChildLaboratoryRequestProcedureCollection SubProcedures
        {
            get
            {
                if (_SubProcedures == null)
                    CreateSubProceduresCollection();
                return _SubProcedures;
            }
        }

        protected LaboratoryRequestProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryRequestProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryRequestProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryRequestProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryRequestProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYREQUESTPROCEDURE", dataRow) { }
        protected LaboratoryRequestProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYREQUESTPROCEDURE", dataRow, isImported) { }
        public LaboratoryRequestProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryRequestProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryRequestProcedure() : base() { }

    }
}