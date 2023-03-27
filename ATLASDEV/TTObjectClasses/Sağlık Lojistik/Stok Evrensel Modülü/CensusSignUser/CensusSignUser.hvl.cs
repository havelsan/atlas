
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CensusSignUser")] 

    /// <summary>
    /// Devir İmza Alanı
    /// </summary>
    public  partial class CensusSignUser : TTObject
    {
        public class CensusSignUserList : TTObjectCollection<CensusSignUser> { }
                    
        public class ChildCensusSignUserCollection : TTObject.TTChildObjectCollection<CensusSignUser>
        {
            public ChildCensusSignUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCensusSignUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sicil No
    /// </summary>
        public string EmploymentRecordID
        {
            get { return (string)this["EMPLOYMENTRECORDID"]; }
            set { this["EMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public SignUserTypeEnum? InspectionUserType
        {
            get { return (SignUserTypeEnum?)(int?)this["INSPECTIONUSERTYPE"]; }
            set { this["INSPECTIONUSERTYPE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string NameString
        {
            get { return (string)this["NAMESTRING"]; }
            set { this["NAMESTRING"] = value; }
        }

    /// <summary>
    /// Sınıf Kısaltması
    /// </summary>
        public string ShortMilitaryClass
        {
            get { return (string)this["SHORTMILITARYCLASS"]; }
            set { this["SHORTMILITARYCLASS"] = value; }
        }

    /// <summary>
    /// Rütbe Kısaltması
    /// </summary>
        public string ShortRank
        {
            get { return (string)this["SHORTRANK"]; }
            set { this["SHORTRANK"] = value; }
        }

        public CheckStockCensusAction CheckStockCensusAction
        {
            get { return (CheckStockCensusAction)((ITTObject)this).GetParent("CHECKSTOCKCENSUSACTION"); }
            set { this["CHECKSTOCKCENSUSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Personelin Adı, Soyadı
    /// </summary>
        public ResUser CensusSignUsers
        {
            get { return (ResUser)((ITTObject)this).GetParent("CENSUSSIGNUSERS"); }
            set { this["CENSUSSIGNUSERS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CensusSignUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CensusSignUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CensusSignUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CensusSignUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CensusSignUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CENSUSSIGNUSER", dataRow) { }
        protected CensusSignUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CENSUSSIGNUSER", dataRow, isImported) { }
        public CensusSignUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CensusSignUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CensusSignUser() : base() { }

    }
}