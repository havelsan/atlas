
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SnomedDiagnosisDefinition")] 

    public  partial class SnomedDiagnosisDefinition : TerminologyManagerDef
    {
        public class SnomedDiagnosisDefinitionList : TTObjectCollection<SnomedDiagnosisDefinition> { }
                    
        public class ChildSnomedDiagnosisDefinitionCollection : TTObject.TTChildObjectCollection<SnomedDiagnosisDefinition>
        {
            public ChildSnomedDiagnosisDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSnomedDiagnosisDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<SnomedDiagnosisDefinition> GetSnomedDiagnosisDefinitionByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SNOMEDDIAGNOSISDEFINITION"].QueryDefs["GetSnomedDiagnosisDefinitionByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SnomedDiagnosisDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kanser
    /// </summary>
        public bool? IsCancer
        {
            get { return (bool?)this["ISCANCER"]; }
            set { this["ISCANCER"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// ICD10Code
    /// </summary>
        public string ICD10Code
        {
            get { return (string)this["ICD10CODE"]; }
            set { this["ICD10CODE"] = value; }
        }

    /// <summary>
    /// İngilizce Name
    /// </summary>
        public string EnglishName
        {
            get { return (string)this["ENGLISHNAME"]; }
            set { this["ENGLISHNAME"] = value; }
        }

        public bool? IsGroup
        {
            get { return (bool?)this["ISGROUP"]; }
            set { this["ISGROUP"] = value; }
        }

    /// <summary>
    /// Referans
    /// </summary>
        public string Reference
        {
            get { return (string)this["REFERENCE"]; }
            set { this["REFERENCE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// ICD 10 Tanısı
    /// </summary>
        public DiagnosisDefinition Diagnosis
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSIS"); }
            set { this["DIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SnomedDiagnosisDefinition ParentGroup
        {
            get { return (SnomedDiagnosisDefinition)((ITTObject)this).GetParent("PARENTGROUP"); }
            set { this["PARENTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSnomedDiagnosisDefinitionsCollection()
        {
            _SnomedDiagnosisDefinitions = new SnomedDiagnosisDefinition.ChildSnomedDiagnosisDefinitionCollection(this, new Guid("6b5ce1ad-1d05-4fd1-8343-2272bf802fbf"));
            ((ITTChildObjectCollection)_SnomedDiagnosisDefinitions).GetChildren();
        }

        protected SnomedDiagnosisDefinition.ChildSnomedDiagnosisDefinitionCollection _SnomedDiagnosisDefinitions = null;
        public SnomedDiagnosisDefinition.ChildSnomedDiagnosisDefinitionCollection SnomedDiagnosisDefinitions
        {
            get
            {
                if (_SnomedDiagnosisDefinitions == null)
                    CreateSnomedDiagnosisDefinitionsCollection();
                return _SnomedDiagnosisDefinitions;
            }
        }

        protected SnomedDiagnosisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SnomedDiagnosisDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SnomedDiagnosisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SnomedDiagnosisDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SnomedDiagnosisDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SNOMEDDIAGNOSISDEFINITION", dataRow) { }
        protected SnomedDiagnosisDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SNOMEDDIAGNOSISDEFINITION", dataRow, isImported) { }
        public SnomedDiagnosisDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SnomedDiagnosisDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SnomedDiagnosisDefinition() : base() { }

    }
}