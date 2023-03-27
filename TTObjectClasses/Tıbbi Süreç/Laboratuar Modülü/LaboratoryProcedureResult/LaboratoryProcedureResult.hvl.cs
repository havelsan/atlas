
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryProcedureResult")] 

    public  partial class LaboratoryProcedureResult : TTObject
    {
        public class LaboratoryProcedureResultList : TTObjectCollection<LaboratoryProcedureResult> { }
                    
        public class ChildLaboratoryProcedureResultCollection : TTObject.TTChildObjectCollection<LaboratoryProcedureResult>
        {
            public ChildLaboratoryProcedureResultCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryProcedureResultCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<LaboratoryProcedureResult> GetByObjectId(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURERESULT"].QueryDefs["GetByObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedureResult>(queryDef, paramList);
        }

    /// <summary>
    /// Sonuç (Cihaz)
    /// </summary>
        public string ResultDev
        {
            get { return (string)this["RESULTDEV"]; }
            set { this["RESULTDEV"] = value; }
        }

    /// <summary>
    /// Sonuç (Manuel)
    /// </summary>
        public string ResultManual
        {
            get { return (string)this["RESULTMANUAL"]; }
            set { this["RESULTMANUAL"] = value; }
        }

    /// <summary>
    /// Sonuc
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

        public LaboratoryProcedure LaboratoryProcedure
        {
            get { return (LaboratoryProcedure)((ITTObject)this).GetParent("LABORATORYPROCEDURE"); }
            set { this["LABORATORYPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// TestDefinition
    /// </summary>
        public LaboratoryTestDefinition TestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("TESTDEFINITION"); }
            set { this["TESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRequestProceduresCollection()
        {
            _RequestProcedures = new LaboratoryRequestProcedure.ChildLaboratoryRequestProcedureCollection(this, new Guid("038b49fc-21ea-406e-b434-1658b872f9a2"));
            ((ITTChildObjectCollection)_RequestProcedures).GetChildren();
        }

        protected LaboratoryRequestProcedure.ChildLaboratoryRequestProcedureCollection _RequestProcedures = null;
        public LaboratoryRequestProcedure.ChildLaboratoryRequestProcedureCollection RequestProcedures
        {
            get
            {
                if (_RequestProcedures == null)
                    CreateRequestProceduresCollection();
                return _RequestProcedures;
            }
        }

        protected LaboratoryProcedureResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryProcedureResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryProcedureResult(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryProcedureResult(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryProcedureResult(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYPROCEDURERESULT", dataRow) { }
        protected LaboratoryProcedureResult(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYPROCEDURERESULT", dataRow, isImported) { }
        public LaboratoryProcedureResult(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryProcedureResult(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryProcedureResult() : base() { }

    }
}