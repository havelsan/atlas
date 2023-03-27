
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnouncementDefinition")] 

    /// <summary>
    /// Duyuru Tanımları
    /// </summary>
    public  partial class AnnouncementDefinition : TerminologyManagerDef
    {
        public class AnnouncementDefinitionList : TTObjectCollection<AnnouncementDefinition> { }
                    
        public class ChildAnnouncementDefinitionCollection : TTObject.TTChildObjectCollection<AnnouncementDefinition>
        {
            public ChildAnnouncementDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnouncementDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAnnouncementDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Link
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LINK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNOUNCEMENTDEFINITION"].AllPropertyDefs["LINK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AnnouncementName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNOUNCEMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNOUNCEMENTDEFINITION"].AllPropertyDefs["ANNOUNCEMENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNOUNCEMENTDEFINITION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNOUNCEMENTDEFINITION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object Announcement
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNOUNCEMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANNOUNCEMENTDEFINITION"].AllPropertyDefs["ANNOUNCEMENT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetAnnouncementDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAnnouncementDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAnnouncementDefinitions_Class() : base() { }
        }

        public static BindingList<AnnouncementDefinition> GetAnnouncementDefinitionsByDate(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNOUNCEMENTDEFINITION"].QueryDefs["GetAnnouncementDefinitionsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<AnnouncementDefinition>(queryDef, paramList);
        }

        public static BindingList<AnnouncementDefinition.GetAnnouncementDefinitions_Class> GetAnnouncementDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNOUNCEMENTDEFINITION"].QueryDefs["GetAnnouncementDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnnouncementDefinition.GetAnnouncementDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnnouncementDefinition.GetAnnouncementDefinitions_Class> GetAnnouncementDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNOUNCEMENTDEFINITION"].QueryDefs["GetAnnouncementDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnnouncementDefinition.GetAnnouncementDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Link
    /// </summary>
        public string Link
        {
            get { return (string)this["LINK"]; }
            set { this["LINK"] = value; }
        }

    /// <summary>
    /// Duyuru Adı
    /// </summary>
        public string AnnouncementName
        {
            get { return (string)this["ANNOUNCEMENTNAME"]; }
            set { this["ANNOUNCEMENTNAME"] = value; }
        }

    /// <summary>
    /// Geçerlilik Başlangıç Süresi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Geçerlilik Bitiş Süresi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Duyuru
    /// </summary>
        public object Announcement
        {
            get { return (object)this["ANNOUNCEMENT"]; }
            set { this["ANNOUNCEMENT"] = value; }
        }

        virtual protected void CreateAnnouncementHospitalsCollection()
        {
            _AnnouncementHospitals = new AnnouncementHospital.ChildAnnouncementHospitalCollection(this, new Guid("2a3940b0-8910-4ee6-80e4-f45bbca47ac9"));
            ((ITTChildObjectCollection)_AnnouncementHospitals).GetChildren();
        }

        protected AnnouncementHospital.ChildAnnouncementHospitalCollection _AnnouncementHospitals = null;
        public AnnouncementHospital.ChildAnnouncementHospitalCollection AnnouncementHospitals
        {
            get
            {
                if (_AnnouncementHospitals == null)
                    CreateAnnouncementHospitalsCollection();
                return _AnnouncementHospitals;
            }
        }

        virtual protected void CreateAnnouncementUserTypesCollection()
        {
            _AnnouncementUserTypes = new AnnouncementUserType.ChildAnnouncementUserTypeCollection(this, new Guid("129e03a5-4dca-41a7-8e1a-becc6d8994d8"));
            ((ITTChildObjectCollection)_AnnouncementUserTypes).GetChildren();
        }

        protected AnnouncementUserType.ChildAnnouncementUserTypeCollection _AnnouncementUserTypes = null;
        public AnnouncementUserType.ChildAnnouncementUserTypeCollection AnnouncementUserTypes
        {
            get
            {
                if (_AnnouncementUserTypes == null)
                    CreateAnnouncementUserTypesCollection();
                return _AnnouncementUserTypes;
            }
        }

        protected AnnouncementDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnouncementDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnouncementDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnouncementDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnouncementDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNOUNCEMENTDEFINITION", dataRow) { }
        protected AnnouncementDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNOUNCEMENTDEFINITION", dataRow, isImported) { }
        public AnnouncementDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnouncementDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnouncementDefinition() : base() { }

    }
}