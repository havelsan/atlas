
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureMaterialMatch")] 

    public  partial class ProcedureMaterialMatch : TTObject
    {
        public class ProcedureMaterialMatchList : TTObjectCollection<ProcedureMaterialMatch> { }
                    
        public class ChildProcedureMaterialMatchCollection : TTObject.TTChildObjectCollection<ProcedureMaterialMatch>
        {
            public ChildProcedureMaterialMatchCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureMaterialMatchCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ProcedureMaterialMatch> GetMatchingObjectList(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREMATERIALMATCH"].QueryDefs["GetMatchingObjectList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ProcedureMaterialMatch>(queryDef, paramList, injectionSQL);
        }

        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public ProcedureDefinition Procedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDURE"); }
            set { this["PROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProcedureMaterialMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureMaterialMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureMaterialMatch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureMaterialMatch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureMaterialMatch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREMATERIALMATCH", dataRow) { }
        protected ProcedureMaterialMatch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREMATERIALMATCH", dataRow, isImported) { }
        public ProcedureMaterialMatch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureMaterialMatch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureMaterialMatch() : base() { }

    }
}