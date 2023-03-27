
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureRequestFormDetailDefinition")] 

    /// <summary>
    /// Hizmet İstek Ekranları Detay Tanımı
    /// </summary>
    public  partial class ProcedureRequestFormDetailDefinition : TTDefinitionSet
    {
        public class ProcedureRequestFormDetailDefinitionList : TTObjectCollection<ProcedureRequestFormDetailDefinition> { }
                    
        public class ChildProcedureRequestFormDetailDefinitionCollection : TTObject.TTChildObjectCollection<ProcedureRequestFormDetailDefinition>
        {
            public ChildProcedureRequestFormDetailDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureRequestFormDetailDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFormDetailByProcedureName_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetFormDetailByProcedureName_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFormDetailByProcedureName_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFormDetailByProcedureName_Class() : base() { }
        }

        public static BindingList<ProcedureRequestFormDetailDefinition> GetProcedureRequestFormDetailByProcedureDefinition(TTObjectContext objectContext, Guid PROCEDUREDEFINITION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDETAILDEFINITION"].QueryDefs["GetProcedureRequestFormDetailByProcedureDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREDEFINITION", PROCEDUREDEFINITION);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureRequestFormDetailDefinition>(queryDef, paramList);
        }

        public static BindingList<ProcedureRequestFormDetailDefinition> GetProcedureRequestFormDetailByObjectId(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDETAILDEFINITION"].QueryDefs["GetProcedureRequestFormDetailByObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureRequestFormDetailDefinition>(queryDef, paramList);
        }

        public static BindingList<ProcedureRequestFormDetailDefinition> GetFormDetailByProcedureDefAndResources(TTObjectContext objectContext, Guid PROCEDUREDEFINITION, IList<Guid> RESOURCEIDS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDETAILDEFINITION"].QueryDefs["GetFormDetailByProcedureDefAndResources"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREDEFINITION", PROCEDUREDEFINITION);
            paramList.Add("RESOURCEIDS", RESOURCEIDS);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureRequestFormDetailDefinition>(queryDef, paramList);
        }

        public static BindingList<ProcedureRequestFormDetailDefinition.GetFormDetailByProcedureName_Class> GetFormDetailByProcedureName(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDETAILDEFINITION"].QueryDefs["GetFormDetailByProcedureName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureRequestFormDetailDefinition.GetFormDetailByProcedureName_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureRequestFormDetailDefinition.GetFormDetailByProcedureName_Class> GetFormDetailByProcedureName(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDETAILDEFINITION"].QueryDefs["GetFormDetailByProcedureName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureRequestFormDetailDefinition.GetFormDetailByProcedureName_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureRequestFormDetailDefinition> GetProcedureRequestFormDetailBySUTCode(TTObjectContext objectContext, string SUTCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDETAILDEFINITION"].QueryDefs["GetProcedureRequestFormDetailBySUTCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTCODE", SUTCODE);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureRequestFormDetailDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Tetkigin hangi sirada gorunecegini belirler
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public ResObservationUnit ObservationUnit
        {
            get { return (ResObservationUnit)((ITTObject)this).GetParent("OBSERVATIONUNIT"); }
            set { this["OBSERVATIONUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Bilgisi
    /// </summary>
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureRequestCategoryDefinition ProcedureRequestCategory
        {
            get { return (ProcedureRequestCategoryDefinition)((ITTObject)this).GetParent("PROCEDUREREQUESTCATEGORY"); }
            set { this["PROCEDUREREQUESTCATEGORY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection PatientAdmissionResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("PATIENTADMISSIONRESSECTION"); }
            set { this["PATIENTADMISSIONRESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProcedureRequestFormDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureRequestFormDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureRequestFormDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureRequestFormDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureRequestFormDetailDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREREQUESTFORMDETAILDEFINITION", dataRow) { }
        protected ProcedureRequestFormDetailDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREREQUESTFORMDETAILDEFINITION", dataRow, isImported) { }
        public ProcedureRequestFormDetailDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureRequestFormDetailDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureRequestFormDetailDefinition() : base() { }

    }
}