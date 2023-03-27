
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SiteMessageQueueCustomization")] 

    public  partial class SiteMessageQueueCustomization : TTDefinitionSet
    {
        public class SiteMessageQueueCustomizationList : TTObjectCollection<SiteMessageQueueCustomization> { }
                    
        public class ChildSiteMessageQueueCustomizationCollection : TTObject.TTChildObjectCollection<SiteMessageQueueCustomization>
        {
            public ChildSiteMessageQueueCustomizationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSiteMessageQueueCustomizationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SiteMessageQueueCustomizationDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsSendingStartStop
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSENDINGSTARTSTOP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITEMESSAGEQUEUECUSTOMIZATION"].AllPropertyDefs["ISSENDINGSTARTSTOP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public SiteMessageQueueCustomizationDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SiteMessageQueueCustomizationDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SiteMessageQueueCustomizationDefinitionQuery_Class() : base() { }
        }

        public static BindingList<SiteMessageQueueCustomization.SiteMessageQueueCustomizationDefinitionQuery_Class> SiteMessageQueueCustomizationDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SITEMESSAGEQUEUECUSTOMIZATION"].QueryDefs["SiteMessageQueueCustomizationDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SiteMessageQueueCustomization.SiteMessageQueueCustomizationDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SiteMessageQueueCustomization.SiteMessageQueueCustomizationDefinitionQuery_Class> SiteMessageQueueCustomizationDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SITEMESSAGEQUEUECUSTOMIZATION"].QueryDefs["SiteMessageQueueCustomizationDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SiteMessageQueueCustomization.SiteMessageQueueCustomizationDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? TurnCount
        {
            get { return (int?)this["TURNCOUNT"]; }
            set { this["TURNCOUNT"] = value; }
        }

        public int? MessageQueueMinVolume
        {
            get { return (int?)this["MESSAGEQUEUEMINVOLUME"]; }
            set { this["MESSAGEQUEUEMINVOLUME"] = value; }
        }

        public DateTime? SendingEndTime
        {
            get { return (DateTime?)this["SENDINGENDTIME"]; }
            set { this["SENDINGENDTIME"] = value; }
        }

        public int? MessageSizeLimit
        {
            get { return (int?)this["MESSAGESIZELIMIT"]; }
            set { this["MESSAGESIZELIMIT"] = value; }
        }

        public int? MessageSuccessiveCount
        {
            get { return (int?)this["MESSAGESUCCESSIVECOUNT"]; }
            set { this["MESSAGESUCCESSIVECOUNT"] = value; }
        }

        public int? MessageQueueMaxVolume
        {
            get { return (int?)this["MESSAGEQUEUEMAXVOLUME"]; }
            set { this["MESSAGEQUEUEMAXVOLUME"] = value; }
        }

        public bool? IsSendingStartStop
        {
            get { return (bool?)this["ISSENDINGSTARTSTOP"]; }
            set { this["ISSENDINGSTARTSTOP"] = value; }
        }

        public DateTime? SendingStartTime
        {
            get { return (DateTime?)this["SENDINGSTARTTIME"]; }
            set { this["SENDINGSTARTTIME"] = value; }
        }

        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSiteRemoteMethodDefCustomizationsCollection()
        {
            _SiteRemoteMethodDefCustomizations = new SiteRemoteMethodDefCustomization.ChildSiteRemoteMethodDefCustomizationCollection(this, new Guid("4cdb80e0-e761-40eb-afe4-2442a982854d"));
            ((ITTChildObjectCollection)_SiteRemoteMethodDefCustomizations).GetChildren();
        }

        protected SiteRemoteMethodDefCustomization.ChildSiteRemoteMethodDefCustomizationCollection _SiteRemoteMethodDefCustomizations = null;
        public SiteRemoteMethodDefCustomization.ChildSiteRemoteMethodDefCustomizationCollection SiteRemoteMethodDefCustomizations
        {
            get
            {
                if (_SiteRemoteMethodDefCustomizations == null)
                    CreateSiteRemoteMethodDefCustomizationsCollection();
                return _SiteRemoteMethodDefCustomizations;
            }
        }

        protected SiteMessageQueueCustomization(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SiteMessageQueueCustomization(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SiteMessageQueueCustomization(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SiteMessageQueueCustomization(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SiteMessageQueueCustomization(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SITEMESSAGEQUEUECUSTOMIZATION", dataRow) { }
        protected SiteMessageQueueCustomization(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SITEMESSAGEQUEUECUSTOMIZATION", dataRow, isImported) { }
        public SiteMessageQueueCustomization(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SiteMessageQueueCustomization(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SiteMessageQueueCustomization() : base() { }

    }
}