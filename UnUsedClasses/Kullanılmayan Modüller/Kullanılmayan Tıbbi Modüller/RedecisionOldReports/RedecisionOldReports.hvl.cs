
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RedecisionOldReports")] 

    /// <summary>
    /// Eski Raporlar
    /// </summary>
    public  partial class RedecisionOldReports : TTObject
    {
        public class RedecisionOldReportsList : TTObjectCollection<RedecisionOldReports> { }
                    
        public class ChildRedecisionOldReportsCollection : TTObject.TTChildObjectCollection<RedecisionOldReports>
        {
            public ChildRedecisionOldReportsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRedecisionOldReportsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dilim
    /// </summary>
        public string Slice
        {
            get { return (string)this["SLICE"]; }
            set { this["SLICE"] = value; }
        }

    /// <summary>
    /// Karar
    /// </summary>
        public string Decision
        {
            get { return (string)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Explanation
        {
            get { return (string)this["EXPLANATION"]; }
            set { this["EXPLANATION"] = value; }
        }

    /// <summary>
    /// Fıkra
    /// </summary>
        public string Anectode
        {
            get { return (string)this["ANECTODE"]; }
            set { this["ANECTODE"] = value; }
        }

    /// <summary>
    /// Madde
    /// </summary>
        public string Matter
        {
            get { return (string)this["MATTER"]; }
            set { this["MATTER"] = value; }
        }

    /// <summary>
    /// Zeyil
    /// </summary>
        public Redecision Redecision
        {
            get { return (Redecision)((ITTObject)this).GetParent("REDECISION"); }
            set { this["REDECISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisDefinition Diagnoses
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSES"); }
            set { this["DIAGNOSES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RedecisionOldReports(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RedecisionOldReports(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RedecisionOldReports(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RedecisionOldReports(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RedecisionOldReports(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REDECISIONOLDREPORTS", dataRow) { }
        protected RedecisionOldReports(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REDECISIONOLDREPORTS", dataRow, isImported) { }
        public RedecisionOldReports(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RedecisionOldReports(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RedecisionOldReports() : base() { }

    }
}