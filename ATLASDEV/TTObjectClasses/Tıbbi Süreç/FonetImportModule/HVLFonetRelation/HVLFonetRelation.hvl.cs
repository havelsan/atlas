
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HVLFonetRelation")] 

    /// <summary>
    /// Fonet Veri Tabanı ile Atlas Veri Aktarımı İlişki Tablosu
    /// </summary>
    public  partial class HVLFonetRelation : TTObject
    {
        public class HVLFonetRelationList : TTObjectCollection<HVLFonetRelation> { }
                    
        public class ChildHVLFonetRelationCollection : TTObject.TTChildObjectCollection<HVLFonetRelation>
        {
            public ChildHVLFonetRelationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHVLFonetRelationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<HVLFonetRelation> GetByTableNameAndFonetObjectID(TTObjectContext objectContext, string TableName, string FonetID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HVLFONETRELATION"].QueryDefs["GetByTableNameAndFonetObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TABLENAME", TableName);
            paramList.Add("FONETID", FonetID);

            return ((ITTQuery)objectContext).QueryObjects<HVLFonetRelation>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<HVLFonetRelation> GetAll(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HVLFONETRELATION"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HVLFonetRelation>(queryDef, paramList);
        }

        public Guid? HvlObjectID
        {
            get { return (Guid?)this["HVLOBJECTID"]; }
            set { this["HVLOBJECTID"] = value; }
        }

        public string FonetObjectID
        {
            get { return (string)this["FONETOBJECTID"]; }
            set { this["FONETOBJECTID"] = value; }
        }

        public string Decription
        {
            get { return (string)this["DECRIPTION"]; }
            set { this["DECRIPTION"] = value; }
        }

        public string FonetTableName
        {
            get { return (string)this["FONETTABLENAME"]; }
            set { this["FONETTABLENAME"] = value; }
        }

        public string FonetDBName
        {
            get { return (string)this["FONETDBNAME"]; }
            set { this["FONETDBNAME"] = value; }
        }

        protected HVLFonetRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HVLFonetRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HVLFonetRelation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HVLFonetRelation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HVLFonetRelation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HVLFONETRELATION", dataRow) { }
        protected HVLFonetRelation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HVLFONETRELATION", dataRow, isImported) { }
        public HVLFonetRelation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HVLFonetRelation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HVLFonetRelation() : base() { }

    }
}