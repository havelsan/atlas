
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaDiagnosisDefinition")] 

    /// <summary>
    /// Medula Tanıları
    /// </summary>
    public  partial class MedulaDiagnosisDefinition : TTDefinitionSet
    {
        public class MedulaDiagnosisDefinitionList : TTObjectCollection<MedulaDiagnosisDefinition> { }
                    
        public class ChildMedulaDiagnosisDefinitionCollection : TTObject.TTChildObjectCollection<MedulaDiagnosisDefinition>
        {
            public ChildMedulaDiagnosisDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaDiagnosisDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MedulaDiagnosisDefinition> GetDiagnosisByCode(TTObjectContext objectContext, string CODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULADIAGNOSISDEFINITION"].QueryDefs["GetDiagnosisByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<MedulaDiagnosisDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Tanı Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Tanı Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Tanı Adı
    /// </summary>
        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
            set { this["NAME_SHADOW"] = value; }
        }

        protected MedulaDiagnosisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaDiagnosisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaDiagnosisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaDiagnosisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaDiagnosisDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULADIAGNOSISDEFINITION", dataRow) { }
        protected MedulaDiagnosisDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULADIAGNOSISDEFINITION", dataRow, isImported) { }
        public MedulaDiagnosisDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaDiagnosisDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaDiagnosisDefinition() : base() { }

    }
}