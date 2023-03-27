
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugAffectingBodyPart")] 

    public  partial class DrugAffectingBodyPart : TerminologyManagerDef
    {
        public class DrugAffectingBodyPartList : TTObjectCollection<DrugAffectingBodyPart> { }
                    
        public class ChildDrugAffectingBodyPartCollection : TTObject.TTChildObjectCollection<DrugAffectingBodyPart>
        {
            public ChildDrugAffectingBodyPartCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugAffectingBodyPartCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugAffectingBodyPartList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? VademecumID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VADEMECUMID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGAFFECTINGBODYPART"].AllPropertyDefs["VADEMECUMID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGAFFECTINGBODYPART"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugAffectingBodyPartList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugAffectingBodyPartList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugAffectingBodyPartList_Class() : base() { }
        }

        public static BindingList<DrugAffectingBodyPart.GetDrugAffectingBodyPartList_Class> GetDrugAffectingBodyPartList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGAFFECTINGBODYPART"].QueryDefs["GetDrugAffectingBodyPartList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugAffectingBodyPart.GetDrugAffectingBodyPartList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugAffectingBodyPart.GetDrugAffectingBodyPartList_Class> GetDrugAffectingBodyPartList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGAFFECTINGBODYPART"].QueryDefs["GetDrugAffectingBodyPartList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugAffectingBodyPart.GetDrugAffectingBodyPartList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public long? VademecumID
        {
            get { return (long?)this["VADEMECUMID"]; }
            set { this["VADEMECUMID"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected DrugAffectingBodyPart(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugAffectingBodyPart(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugAffectingBodyPart(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugAffectingBodyPart(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugAffectingBodyPart(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGAFFECTINGBODYPART", dataRow) { }
        protected DrugAffectingBodyPart(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGAFFECTINGBODYPART", dataRow, isImported) { }
        public DrugAffectingBodyPart(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugAffectingBodyPart(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugAffectingBodyPart() : base() { }

    }
}