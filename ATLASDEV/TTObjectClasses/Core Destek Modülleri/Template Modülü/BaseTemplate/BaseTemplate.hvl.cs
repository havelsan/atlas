
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseTemplate")] 

    public  abstract  partial class BaseTemplate : TTObject
    {
        public class BaseTemplateList : TTObjectCollection<BaseTemplate> { }
                    
        public class ChildBaseTemplateCollection : TTObject.TTChildObjectCollection<BaseTemplate>
        {
            public ChildBaseTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<BaseTemplate> GetDefaultTemplates(TTObjectContext objectContext, string RTFTEMPLATEGROUPPARAMETER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETEMPLATE"].QueryDefs["GetDefaultTemplates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RTFTEMPLATEGROUPPARAMETER", RTFTEMPLATEGROUPPARAMETER);

            return ((ITTQuery)objectContext).QueryObjects<BaseTemplate>(queryDef, paramList);
        }

        public static BindingList<BaseTemplate> GetUserTemplates(TTObjectContext objectContext, string RTFTEMPLATEGROUPPARAMETER, string RESUSERPARAMETER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETEMPLATE"].QueryDefs["GetUserTemplates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RTFTEMPLATEGROUPPARAMETER", RTFTEMPLATEGROUPPARAMETER);
            paramList.Add("RESUSERPARAMETER", RESUSERPARAMETER);

            return ((ITTQuery)objectContext).QueryObjects<BaseTemplate>(queryDef, paramList);
        }

        public static BindingList<BaseTemplate> GetUserAndDefaultTemplates(TTObjectContext objectContext, string RESUSERPARAMETER, string RTFTEMPLATEGROUPPARAMETER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETEMPLATE"].QueryDefs["GetUserAndDefaultTemplates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSERPARAMETER", RESUSERPARAMETER);
            paramList.Add("RTFTEMPLATEGROUPPARAMETER", RTFTEMPLATEGROUPPARAMETER);

            return ((ITTQuery)objectContext).QueryObjects<BaseTemplate>(queryDef, paramList);
        }

        public static BindingList<BaseTemplate> GetHospitalTemplates(TTObjectContext objectContext, string RTFTEMPLATEGROUPPARAMETER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETEMPLATE"].QueryDefs["GetHospitalTemplates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RTFTEMPLATEGROUPPARAMETER", RTFTEMPLATEGROUPPARAMETER);

            return ((ITTQuery)objectContext).QueryObjects<BaseTemplate>(queryDef, paramList);
        }

    /// <summary>
    /// İçerik
    /// </summary>
        public object Content
        {
            get { return (object)this["CONTENT"]; }
            set { this["CONTENT"] = value; }
        }

    /// <summary>
    /// Menü Başlığı
    /// </summary>
        public string MenuCaption
        {
            get { return (string)this["MENUCAPTION"]; }
            set { this["MENUCAPTION"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public bool? Enabled
        {
            get { return (bool?)this["ENABLED"]; }
            set { this["ENABLED"] = value; }
        }

    /// <summary>
    /// Şablon Grubu
    /// </summary>
        public TemplateGroup TemplateGroup
        {
            get { return (TemplateGroup)((ITTObject)this).GetParent("TEMPLATEGROUP"); }
            set { this["TEMPLATEGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASETEMPLATE", dataRow) { }
        protected BaseTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASETEMPLATE", dataRow, isImported) { }
        public BaseTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseTemplate() : base() { }

    }
}