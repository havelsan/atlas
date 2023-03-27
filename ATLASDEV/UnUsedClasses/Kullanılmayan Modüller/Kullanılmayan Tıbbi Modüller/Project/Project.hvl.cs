
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Project")] 

    /// <summary>
    /// DE_Proje
    /// </summary>
    public  partial class Project : TTObject
    {
        public class ProjectList : TTObjectCollection<Project> { }
                    
        public class ChildProjectCollection : TTObject.TTChildObjectCollection<Project>
        {
            public ChildProjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ücret
    /// </summary>
        public double? Cost
        {
            get { return (double?)this["COST"]; }
            set { this["COST"] = value; }
        }

    /// <summary>
    /// Proje Türü
    /// </summary>
        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Proje Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Proje Durumu
    /// </summary>
        public int? Status
        {
            get { return (int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? FinishDate
        {
            get { return (DateTime?)this["FINISHDATE"]; }
            set { this["FINISHDATE"] = value; }
        }

    /// <summary>
    /// Proje Amacı
    /// </summary>
        public string Aim
        {
            get { return (string)this["AIM"]; }
            set { this["AIM"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartTime
        {
            get { return (DateTime?)this["STARTTIME"]; }
            set { this["STARTTIME"] = value; }
        }

        protected Project(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Project(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Project(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Project(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Project(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECT", dataRow) { }
        protected Project(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECT", dataRow, isImported) { }
        public Project(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Project(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Project() : base() { }

    }
}