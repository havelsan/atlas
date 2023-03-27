
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PainChangingSituationDefinition")] 

    /// <summary>
    /// Ağrı Değerlendirme Tanımlama
    /// </summary>
    public  partial class PainChangingSituationDefinition : TerminologyManagerDef
    {
        public class PainChangingSituationDefinitionList : TTObjectCollection<PainChangingSituationDefinition> { }
                    
        public class ChildPainChangingSituationDefinitionCollection : TTObject.TTChildObjectCollection<PainChangingSituationDefinition>
        {
            public ChildPainChangingSituationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPainChangingSituationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPainChangingSituation_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAINCHANGINGSITUATIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Increasing
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCREASING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAINCHANGINGSITUATIONDEFINITION"].AllPropertyDefs["INCREASING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Decreasing
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECREASING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAINCHANGINGSITUATIONDEFINITION"].AllPropertyDefs["DECREASING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPainChangingSituation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPainChangingSituation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPainChangingSituation_Class() : base() { }
        }

        public static BindingList<PainChangingSituationDefinition.GetPainChangingSituation_Class> GetPainChangingSituation(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINCHANGINGSITUATIONDEFINITION"].QueryDefs["GetPainChangingSituation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PainChangingSituationDefinition.GetPainChangingSituation_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PainChangingSituationDefinition.GetPainChangingSituation_Class> GetPainChangingSituation(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINCHANGINGSITUATIONDEFINITION"].QueryDefs["GetPainChangingSituation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PainChangingSituationDefinition.GetPainChangingSituation_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PainChangingSituationDefinition> GetPainChangingSituationDef(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINCHANGINGSITUATIONDEFINITION"].QueryDefs["GetPainChangingSituationDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PainChangingSituationDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Artan ağrı
    /// </summary>
        public bool? Increasing
        {
            get { return (bool?)this["INCREASING"]; }
            set { this["INCREASING"] = value; }
        }

    /// <summary>
    /// Azalan
    /// </summary>
        public bool? Decreasing
        {
            get { return (bool?)this["DECREASING"]; }
            set { this["DECREASING"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected PainChangingSituationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PainChangingSituationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PainChangingSituationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PainChangingSituationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PainChangingSituationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAINCHANGINGSITUATIONDEFINITION", dataRow) { }
        protected PainChangingSituationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAINCHANGINGSITUATIONDEFINITION", dataRow, isImported) { }
        public PainChangingSituationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PainChangingSituationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PainChangingSituationDefinition() : base() { }

    }
}