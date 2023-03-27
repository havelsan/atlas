
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Committee")] 

    /// <summary>
    /// Komite
    /// </summary>
    public  partial class Committee : TTObject
    {
        public class CommitteeList : TTObjectCollection<Committee> { }
                    
        public class ChildCommitteeCollection : TTObject.TTChildObjectCollection<Committee>
        {
            public ChildCommitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Asil/Yedek
    /// </summary>
        public bool? PrimeBackup
        {
            get { return (bool?)this["PRIMEBACKUP"]; }
            set { this["PRIMEBACKUP"] = value; }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public string ClassRank
        {
            get { return (string)this["CLASSRANK"]; }
            set { this["CLASSRANK"] = value; }
        }

    /// <summary>
    /// Ad Soyad
    /// </summary>
        public string NameSurname
        {
            get { return (string)this["NAMESURNAME"]; }
            set { this["NAMESURNAME"] = value; }
        }

    /// <summary>
    /// Ünvan
    /// </summary>
        public string JobTitle
        {
            get { return (string)this["JOBTITLE"]; }
            set { this["JOBTITLE"] = value; }
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public string CommitteeDuty
        {
            get { return (string)this["COMMITTEEDUTY"]; }
            set { this["COMMITTEEDUTY"] = value; }
        }

        protected Committee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Committee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Committee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Committee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Committee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMITTEE", dataRow) { }
        protected Committee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMITTEE", dataRow, isImported) { }
        public Committee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Committee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Committee() : base() { }

    }
}