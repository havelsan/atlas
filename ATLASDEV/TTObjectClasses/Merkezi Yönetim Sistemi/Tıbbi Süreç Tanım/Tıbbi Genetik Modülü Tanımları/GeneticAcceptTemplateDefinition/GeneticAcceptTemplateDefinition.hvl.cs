
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneticAcceptTemplateDefinition")] 

    /// <summary>
    /// Genetik Paket Tanımları
    /// </summary>
    public  partial class GeneticAcceptTemplateDefinition : ProcedureRequestTemplateDefinition
    {
        public class GeneticAcceptTemplateDefinitionList : TTObjectCollection<GeneticAcceptTemplateDefinition> { }
                    
        public class ChildGeneticAcceptTemplateDefinitionCollection : TTObject.TTChildObjectCollection<GeneticAcceptTemplateDefinition>
        {
            public ChildGeneticAcceptTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneticAcceptTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetGeneticAcceptTemplateNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENETICACCEPTTEMPLATEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetGeneticAcceptTemplateNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGeneticAcceptTemplateNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGeneticAcceptTemplateNQL_Class() : base() { }
        }

        public static BindingList<GeneticAcceptTemplateDefinition.GetGeneticAcceptTemplateNQL_Class> GetGeneticAcceptTemplateNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICACCEPTTEMPLATEDEFINITION"].QueryDefs["GetGeneticAcceptTemplateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GeneticAcceptTemplateDefinition.GetGeneticAcceptTemplateNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GeneticAcceptTemplateDefinition.GetGeneticAcceptTemplateNQL_Class> GetGeneticAcceptTemplateNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENETICACCEPTTEMPLATEDEFINITION"].QueryDefs["GetGeneticAcceptTemplateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GeneticAcceptTemplateDefinition.GetGeneticAcceptTemplateNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateGeneticAcceptTemplateDetailsCollection()
        {
            _GeneticAcceptTemplateDetails = new GeneticAcceptTemplateDetail.ChildGeneticAcceptTemplateDetailCollection(this, new Guid("5ac9ab75-e709-4cae-ba2b-ae0b8b54632b"));
            ((ITTChildObjectCollection)_GeneticAcceptTemplateDetails).GetChildren();
        }

        protected GeneticAcceptTemplateDetail.ChildGeneticAcceptTemplateDetailCollection _GeneticAcceptTemplateDetails = null;
    /// <summary>
    /// Child collection for Genetik Paket Detay Tanımı İlişkisi
    /// </summary>
        public GeneticAcceptTemplateDetail.ChildGeneticAcceptTemplateDetailCollection GeneticAcceptTemplateDetails
        {
            get
            {
                if (_GeneticAcceptTemplateDetails == null)
                    CreateGeneticAcceptTemplateDetailsCollection();
                return _GeneticAcceptTemplateDetails;
            }
        }

        protected GeneticAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneticAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneticAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneticAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneticAcceptTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENETICACCEPTTEMPLATEDEFINITION", dataRow) { }
        protected GeneticAcceptTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENETICACCEPTTEMPLATEDEFINITION", dataRow, isImported) { }
        public GeneticAcceptTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneticAcceptTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneticAcceptTemplateDefinition() : base() { }

    }
}