
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CKYSUserType")] 

    public  partial class CKYSUserType : TerminologyManagerDef
    {
        public class CKYSUserTypeList : TTObjectCollection<CKYSUserType> { }
                    
        public class ChildCKYSUserTypeCollection : TTObject.TTChildObjectCollection<CKYSUserType>
        {
            public ChildCKYSUserTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCKYSUserTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<CKYSUserType> GetCKYSUserTypeByCode(TTObjectContext objectContext, int CKYSCode)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CKYSUSERTYPE"].QueryDefs["GetCKYSUserTypeByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CKYSCODE", CKYSCode);

            return ((ITTQuery)objectContext).QueryObjects<CKYSUserType>(queryDef, paramList);
        }

    /// <summary>
    /// Bütün listeyi getiren nql
    /// </summary>
        public static BindingList<CKYSUserType> GetAllCKYSUserType(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CKYSUSERTYPE"].QueryDefs["GetAllCKYSUserType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<CKYSUserType>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// CKYS Kodu
    /// </summary>
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

        public UserTypeEnum? UserType
        {
            get { return (UserTypeEnum?)(int?)this["USERTYPE"]; }
            set { this["USERTYPE"] = value; }
        }

        protected CKYSUserType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CKYSUserType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CKYSUserType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CKYSUserType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CKYSUserType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CKYSUSERTYPE", dataRow) { }
        protected CKYSUserType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CKYSUSERTYPE", dataRow, isImported) { }
        public CKYSUserType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CKYSUserType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CKYSUserType() : base() { }

    }
}