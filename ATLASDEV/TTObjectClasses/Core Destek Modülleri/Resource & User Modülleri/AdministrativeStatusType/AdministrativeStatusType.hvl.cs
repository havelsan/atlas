
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdministrativeStatusType")] 

    public  partial class AdministrativeStatusType : TTDefinitionSet
    {
        public class AdministrativeStatusTypeList : TTObjectCollection<AdministrativeStatusType> { }
                    
        public class ChildAdministrativeStatusTypeCollection : TTObject.TTChildObjectCollection<AdministrativeStatusType>
        {
            public ChildAdministrativeStatusTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdministrativeStatusTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<AdministrativeStatusType> GetByCode(TTObjectContext objectContext, int Code)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMINISTRATIVESTATUSTYPE"].QueryDefs["GetByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", Code);

            return ((ITTQuery)objectContext).QueryObjects<AdministrativeStatusType>(queryDef, paramList);
        }

        public static BindingList<AdministrativeStatusType> GetAllAdministrativeStatusType(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMINISTRATIVESTATUSTYPE"].QueryDefs["GetAllAdministrativeStatusType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<AdministrativeStatusType>(queryDef, paramList, injectionSQL);
        }

        public string DisplayText
        {
            get { return (string)this["DISPLAYTEXT"]; }
            set { this["DISPLAYTEXT"] = value; }
        }

        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected AdministrativeStatusType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdministrativeStatusType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdministrativeStatusType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdministrativeStatusType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdministrativeStatusType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADMINISTRATIVESTATUSTYPE", dataRow) { }
        protected AdministrativeStatusType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADMINISTRATIVESTATUSTYPE", dataRow, isImported) { }
        public AdministrativeStatusType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdministrativeStatusType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdministrativeStatusType() : base() { }

    }
}