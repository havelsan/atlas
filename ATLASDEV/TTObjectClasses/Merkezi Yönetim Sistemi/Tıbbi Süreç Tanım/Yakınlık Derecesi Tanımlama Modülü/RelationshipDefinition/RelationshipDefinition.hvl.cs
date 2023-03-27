
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RelationshipDefinition")] 

    /// <summary>
    /// Yakınlık Derecesi Tanımları
    /// </summary>
    public  partial class RelationshipDefinition : TerminologyManagerDef
    {
        public class RelationshipDefinitionList : TTObjectCollection<RelationshipDefinition> { }
                    
        public class ChildRelationshipDefinitionCollection : TTObject.TTChildObjectCollection<RelationshipDefinition>
        {
            public ChildRelationshipDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRelationshipDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRelationShipNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Relationship
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIONSHIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].AllPropertyDefs["RELATIONSHIP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShortName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRelationShipNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRelationShipNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRelationShipNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_RelationShipDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Relationship
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIONSHIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].AllPropertyDefs["RELATIONSHIP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShortName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_RelationShipDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_RelationShipDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_RelationShipDefinition_Class() : base() { }
        }

        public static BindingList<RelationshipDefinition.GetRelationShipNQL_Class> GetRelationShipNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].QueryDefs["GetRelationShipNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RelationshipDefinition.GetRelationShipNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RelationshipDefinition.GetRelationShipNQL_Class> GetRelationShipNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].QueryDefs["GetRelationShipNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RelationshipDefinition.GetRelationShipNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RelationshipDefinition> GetRelationshipByExternalCode(TTObjectContext objectContext, string EXTERNALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].QueryDefs["GetRelationshipByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<RelationshipDefinition>(queryDef, paramList);
        }

        public static BindingList<RelationshipDefinition> GetRelationshipDefinitionfByUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].QueryDefs["GetRelationshipDefinitionfByUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<RelationshipDefinition>(queryDef, paramList);
        }

        public static BindingList<RelationshipDefinition.OLAP_RelationShipDefinition_Class> OLAP_RelationShipDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].QueryDefs["OLAP_RelationShipDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RelationshipDefinition.OLAP_RelationShipDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RelationshipDefinition.OLAP_RelationShipDefinition_Class> OLAP_RelationShipDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RELATIONSHIPDEFINITION"].QueryDefs["OLAP_RelationShipDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RelationshipDefinition.OLAP_RelationShipDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yakınlık Derecesi
    /// </summary>
        public string Relationship
        {
            get { return (string)this["RELATIONSHIP"]; }
            set { this["RELATIONSHIP"] = value; }
        }

    /// <summary>
    /// Akıllı Kart Klavuz Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Kısa Adı
    /// </summary>
        public string ShortName
        {
            get { return (string)this["SHORTNAME"]; }
            set { this["SHORTNAME"] = value; }
        }

        public string Relationship_Shadow
        {
            get { return (string)this["RELATIONSHIP_SHADOW"]; }
        }

    /// <summary>
    /// Akıllı Kart Yakınlık Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        virtual protected void CreatePatientExamParticipDetailCollection()
        {
            _PatientExamParticipDetail = new PatientExamParticipDetail.ChildPatientExamParticipDetailCollection(this, new Guid("05752f76-842b-49bc-a680-fc7efaf646ba"));
            ((ITTChildObjectCollection)_PatientExamParticipDetail).GetChildren();
        }

        protected PatientExamParticipDetail.ChildPatientExamParticipDetailCollection _PatientExamParticipDetail = null;
    /// <summary>
    /// Child collection for Muayene Katkı Payından Muaf olan Yakınlık Dereceleri ilişkisi
    /// </summary>
        public PatientExamParticipDetail.ChildPatientExamParticipDetailCollection PatientExamParticipDetail
        {
            get
            {
                if (_PatientExamParticipDetail == null)
                    CreatePatientExamParticipDetailCollection();
                return _PatientExamParticipDetail;
            }
        }

        protected RelationshipDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RelationshipDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RelationshipDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RelationshipDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RelationshipDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RELATIONSHIPDEFINITION", dataRow) { }
        protected RelationshipDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RELATIONSHIPDEFINITION", dataRow, isImported) { }
        protected RelationshipDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RelationshipDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RelationshipDefinition() : base() { }

    }
}