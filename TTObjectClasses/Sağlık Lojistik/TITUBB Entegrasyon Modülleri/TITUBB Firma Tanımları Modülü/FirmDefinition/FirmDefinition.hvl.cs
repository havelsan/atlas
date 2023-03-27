
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FirmDefinition")] 

    /// <summary>
    /// TITUB Firma Tanımı
    /// </summary>
    public  partial class FirmDefinition : TerminologyManagerDef
    {
        public class FirmDefinitionList : TTObjectCollection<FirmDefinition> { }
                    
        public class ChildFirmDefinitionCollection : TTObject.TTChildObjectCollection<FirmDefinition>
        {
            public ChildFirmDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFirmDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<FirmDefinition> GetFirmByIdentityNumber(TTObjectContext objectContext, long IDENTITYNUMBER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIRMDEFINITION"].QueryDefs["GetFirmByIdentityNumber"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("IDENTITYNUMBER", IDENTITYNUMBER);

            return ((ITTQuery)objectContext).QueryObjects<FirmDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Adres
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// Firma Tanımlayıcı Numarası
    /// </summary>
        public long? IdentityNumber
        {
            get { return (long?)this["IDENTITYNUMBER"]; }
            set { this["IDENTITYNUMBER"] = value; }
        }

    /// <summary>
    /// Firma Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// TITUBBFirmID
    /// </summary>
        public string TITUBBFirmID
        {
            get { return (string)this["TITUBBFIRMID"]; }
            set { this["TITUBBFIRMID"] = value; }
        }

    /// <summary>
    /// Kuruluş Tarihi
    /// </summary>
        public DateTime? Since
        {
            get { return (DateTime?)this["SINCE"]; }
            set { this["SINCE"] = value; }
        }

        protected FirmDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FirmDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FirmDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FirmDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FirmDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIRMDEFINITION", dataRow) { }
        protected FirmDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIRMDEFINITION", dataRow, isImported) { }
        public FirmDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FirmDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FirmDefinition() : base() { }

    }
}