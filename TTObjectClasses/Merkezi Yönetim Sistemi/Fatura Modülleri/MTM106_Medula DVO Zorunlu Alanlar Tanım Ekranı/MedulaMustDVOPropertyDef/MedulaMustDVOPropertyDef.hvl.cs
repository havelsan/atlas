
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaMustDVOPropertyDef")] 

    /// <summary>
    /// Medula DVO Zorunlu Alanlar Tanım Ekranı
    /// </summary>
    public  partial class MedulaMustDVOPropertyDef : TTDefinitionSet
    {
        public class MedulaMustDVOPropertyDefList : TTObjectCollection<MedulaMustDVOPropertyDef> { }
                    
        public class ChildMedulaMustDVOPropertyDefCollection : TTObject.TTChildObjectCollection<MedulaMustDVOPropertyDef>
        {
            public ChildMedulaMustDVOPropertyDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaMustDVOPropertyDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MedulaMustDVOPropertyDef> GetMedulaMustDVOProperties(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAMUSTDVOPROPERTYDEF"].QueryDefs["GetMedulaMustDVOProperties"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<MedulaMustDVOPropertyDef>(queryDef, paramList);
        }

        public static BindingList<MedulaMustDVOPropertyDef> GetMedulaMustDVOPropertiesByDVOName(TTObjectContext objectContext, string DVONAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAMUSTDVOPROPERTYDEF"].QueryDefs["GetMedulaMustDVOPropertiesByDVOName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DVONAME", DVONAME);

            return ((ITTQuery)objectContext).QueryObjects<MedulaMustDVOPropertyDef>(queryDef, paramList);
        }

    /// <summary>
    /// Alan Adı
    /// </summary>
        public string PropertyName
        {
            get { return (string)this["PROPERTYNAME"]; }
            set { this["PROPERTYNAME"] = value; }
        }

    /// <summary>
    /// DVO Adı
    /// </summary>
        public string DVOName
        {
            get { return (string)this["DVONAME"]; }
            set { this["DVONAME"] = value; }
        }

        public TedaviTuru TedaviTuru
        {
            get { return (TedaviTuru)((ITTObject)this).GetParent("TEDAVITURU"); }
            set { this["TEDAVITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaMustDVOPropertyDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaMustDVOPropertyDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaMustDVOPropertyDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaMustDVOPropertyDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaMustDVOPropertyDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAMUSTDVOPROPERTYDEF", dataRow) { }
        protected MedulaMustDVOPropertyDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAMUSTDVOPROPERTYDEF", dataRow, isImported) { }
        public MedulaMustDVOPropertyDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaMustDVOPropertyDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaMustDVOPropertyDef() : base() { }

    }
}