
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TraditionalAlternativeProcedure")] 

    /// <summary>
    /// Geleneksel Alternatif Tamamlayıcı Uygulama İşlemleri
    /// </summary>
    public  partial class TraditionalAlternativeProcedure : SubActionProcedure
    {
        public class TraditionalAlternativeProcedureList : TTObjectCollection<TraditionalAlternativeProcedure> { }
                    
        public class ChildTraditionalAlternativeProcedureCollection : TTObject.TTChildObjectCollection<TraditionalAlternativeProcedure>
        {
            public ChildTraditionalAlternativeProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTraditionalAlternativeProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTraditionalAlternativeReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? EpisodeAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTION"]);
                }
            }

            public GetTraditionalAlternativeReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTraditionalAlternativeReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTraditionalAlternativeReportNQL_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<TraditionalAlternativeProcedure.GetTraditionalAlternativeReportNQL_Class> GetTraditionalAlternativeReportNQL(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TRADITIONALALTERNATIVEPROCEDURE"].QueryDefs["GetTraditionalAlternativeReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<TraditionalAlternativeProcedure.GetTraditionalAlternativeReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<TraditionalAlternativeProcedure.GetTraditionalAlternativeReportNQL_Class> GetTraditionalAlternativeReportNQL(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TRADITIONALALTERNATIVEPROCEDURE"].QueryDefs["GetTraditionalAlternativeReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<TraditionalAlternativeProcedure.GetTraditionalAlternativeReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// İşlemin Yapıldığı Birim
    /// </summary>
        public ResSection ProcedureDepartment
        {
            get { return (ResSection)((ITTObject)this).GetParent("PROCEDUREDEPARTMENT"); }
            set { this["PROCEDUREDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TraditionalAlternative TraditionalAlternative
        {
            get { return (TraditionalAlternative)((ITTObject)this).GetParent("TRADITIONALALTERNATIVE"); }
            set { this["TRADITIONALALTERNATIVE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TraditionalAlternativeProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TraditionalAlternativeProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TraditionalAlternativeProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TraditionalAlternativeProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TraditionalAlternativeProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRADITIONALALTERNATIVEPROCEDURE", dataRow) { }
        protected TraditionalAlternativeProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRADITIONALALTERNATIVEPROCEDURE", dataRow, isImported) { }
        public TraditionalAlternativeProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TraditionalAlternativeProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TraditionalAlternativeProcedure() : base() { }

    }
}