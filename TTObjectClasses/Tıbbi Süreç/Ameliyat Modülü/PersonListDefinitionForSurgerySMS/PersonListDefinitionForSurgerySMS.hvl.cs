
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PersonListDefinitionForSurgerySMS")] 

    /// <summary>
    /// Rapor Yazılmayan Ameliyatlar İçin Bilgilendirilecekler
    /// </summary>
    public  partial class PersonListDefinitionForSurgerySMS : TerminologyManagerDef
    {
        public class PersonListDefinitionForSurgerySMSList : TTObjectCollection<PersonListDefinitionForSurgerySMS> { }
                    
        public class ChildPersonListDefinitionForSurgerySMSCollection : TTObject.TTChildObjectCollection<PersonListDefinitionForSurgerySMS>
        {
            public ChildPersonListDefinitionForSurgerySMSCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPersonListDefinitionForSurgerySMSCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAllPersonListForSurgery_RQ_Class : TTReportNqlObject 
        {
            public string Resusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetAllPersonListForSurgery_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllPersonListForSurgery_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllPersonListForSurgery_RQ_Class() : base() { }
        }

        public static BindingList<PersonListDefinitionForSurgerySMS.GetAllPersonListForSurgery_RQ_Class> GetAllPersonListForSurgery_RQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PERSONLISTDEFINITIONFORSURGERYSMS"].QueryDefs["GetAllPersonListForSurgery_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PersonListDefinitionForSurgerySMS.GetAllPersonListForSurgery_RQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PersonListDefinitionForSurgerySMS.GetAllPersonListForSurgery_RQ_Class> GetAllPersonListForSurgery_RQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PERSONLISTDEFINITIONFORSURGERYSMS"].QueryDefs["GetAllPersonListForSurgery_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PersonListDefinitionForSurgerySMS.GetAllPersonListForSurgery_RQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PersonListDefinitionForSurgerySMS> GetAllPersonListForSurgery(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PERSONLISTDEFINITIONFORSURGERYSMS"].QueryDefs["GetAllPersonListForSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PersonListDefinitionForSurgerySMS>(queryDef, paramList, injectionSQL);
        }

        public string SMSText
        {
            get { return (string)this["SMSTEXT"]; }
            set { this["SMSTEXT"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PersonListDefinitionForSurgerySMS(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PersonListDefinitionForSurgerySMS(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PersonListDefinitionForSurgerySMS(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PersonListDefinitionForSurgerySMS(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PersonListDefinitionForSurgerySMS(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PERSONLISTDEFINITIONFORSURGERYSMS", dataRow) { }
        protected PersonListDefinitionForSurgerySMS(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PERSONLISTDEFINITIONFORSURGERYSMS", dataRow, isImported) { }
        public PersonListDefinitionForSurgerySMS(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PersonListDefinitionForSurgerySMS(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PersonListDefinitionForSurgerySMS() : base() { }

    }
}