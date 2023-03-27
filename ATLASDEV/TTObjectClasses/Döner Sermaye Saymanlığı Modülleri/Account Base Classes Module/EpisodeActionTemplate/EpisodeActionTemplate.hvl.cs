
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeActionTemplate")] 

    /// <summary>
    /// Vaka İşlemleri Şablonu
    /// </summary>
    public  partial class EpisodeActionTemplate : TTDefinitionSet
    {
        public class EpisodeActionTemplateList : TTObjectCollection<EpisodeActionTemplate> { }
                    
        public class ChildEpisodeActionTemplateCollection : TTObject.TTChildObjectCollection<EpisodeActionTemplate>
        {
            public ChildEpisodeActionTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeActionTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEpisodeActionTemplate_Class : TTReportNqlObject 
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

            public ActionTypeEnum? ActionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONTEMPLATE"].AllPropertyDefs["ACTIONTYPE"].DataType;
                    return (ActionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONTEMPLATE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEpisodeActionTemplate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeActionTemplate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeActionTemplate_Class() : base() { }
        }

        public static BindingList<EpisodeActionTemplate.GetEpisodeActionTemplate_Class> GetEpisodeActionTemplate(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONTEMPLATE"].QueryDefs["GetEpisodeActionTemplate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeActionTemplate.GetEpisodeActionTemplate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeActionTemplate.GetEpisodeActionTemplate_Class> GetEpisodeActionTemplate(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTIONTEMPLATE"].QueryDefs["GetEpisodeActionTemplate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeActionTemplate.GetEpisodeActionTemplate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kaynağa Göre Başlatılacak İşlem
    /// </summary>
        public ActionTypeEnum? ActionType
        {
            get { return (ActionTypeEnum?)(int?)this["ACTIONTYPE"]; }
            set { this["ACTIONTYPE"] = value; }
        }

    /// <summary>
    /// Şablon Açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kaynak
    /// </summary>
        public ResSection Resource
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProcedureDefinitionsCollection()
        {
            _ProcedureDefinitions = new EpisodeActionProcedureObjectTemplate.ChildEpisodeActionProcedureObjectTemplateCollection(this, new Guid("05b4e773-7d3a-4f33-8068-80f04924bdb7"));
            ((ITTChildObjectCollection)_ProcedureDefinitions).GetChildren();
        }

        protected EpisodeActionProcedureObjectTemplate.ChildEpisodeActionProcedureObjectTemplateCollection _ProcedureDefinitions = null;
        public EpisodeActionProcedureObjectTemplate.ChildEpisodeActionProcedureObjectTemplateCollection ProcedureDefinitions
        {
            get
            {
                if (_ProcedureDefinitions == null)
                    CreateProcedureDefinitionsCollection();
                return _ProcedureDefinitions;
            }
        }

        protected EpisodeActionTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeActionTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeActionTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeActionTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeActionTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEACTIONTEMPLATE", dataRow) { }
        protected EpisodeActionTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEACTIONTEMPLATE", dataRow, isImported) { }
        public EpisodeActionTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeActionTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeActionTemplate() : base() { }

    }
}