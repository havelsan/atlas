
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseSKRSDefinition")] 

    /// <summary>
    /// Farklı SKRS Kodlarının bağlı olduğu base
    /// </summary>
    public  partial class BaseSKRSDefinition : TerminologyManagerDef
    {
        public class BaseSKRSDefinitionList : TTObjectCollection<BaseSKRSDefinition> { }
                    
        public class ChildBaseSKRSDefinitionCollection : TTObject.TTChildObjectCollection<BaseSKRSDefinition>
        {
            public ChildBaseSKRSDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseSKRSDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<BaseSKRSDefinition> GetBaseSKRSDefinition(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASESKRSDEFINITION"].QueryDefs["GetBaseSKRSDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BaseSKRSDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<BaseSKRSDefinition> GetDefaultBySKRSDefObjectId(TTObjectContext objectContext, Guid SKRSDEFOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASESKRSDEFINITION"].QueryDefs["GetDefaultBySKRSDefObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SKRSDEFOBJECTID", SKRSDEFOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<BaseSKRSDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// sistemden girilen enumların SKRS tanımlarında karşılık bulamadığında default bu değer atılır
    /// </summary>
        public bool? Default
        {
            get { return (bool?)this["DEFAULT"]; }
            set { this["DEFAULT"] = value; }
        }

        public string AKTIF
        {
            get { return (string)this["AKTIF"]; }
            set { this["AKTIF"] = value; }
        }

        public DateTime? OLUSTURULMATARIHI
        {
            get { return (DateTime?)this["OLUSTURULMATARIHI"]; }
            set { this["OLUSTURULMATARIHI"] = value; }
        }

        public DateTime? GUNCELLENMETARIHI
        {
            get { return (DateTime?)this["GUNCELLENMETARIHI"]; }
            set { this["GUNCELLENMETARIHI"] = value; }
        }

        public DateTime? PASIFEALINMATARIHI
        {
            get { return (DateTime?)this["PASIFEALINMATARIHI"]; }
            set { this["PASIFEALINMATARIHI"] = value; }
        }

        public DateTime? GUNCELLEMETARIHI
        {
            get { return (DateTime?)this["GUNCELLEMETARIHI"]; }
            set { this["GUNCELLEMETARIHI"] = value; }
        }

        protected BaseSKRSDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseSKRSDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseSKRSDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseSKRSDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseSKRSDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASESKRSDEFINITION", dataRow) { }
        protected BaseSKRSDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASESKRSDEFINITION", dataRow, isImported) { }
        public BaseSKRSDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseSKRSDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseSKRSDefinition() : base() { }

    }
}