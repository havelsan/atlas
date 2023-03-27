
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrCreatingEpicrisis")] 

    /// <summary>
    /// Epikriz Oluşturma
    /// </summary>
    public  partial class ehrCreatingEpicrisis : ehrEpisodeAction
    {
        public class ehrCreatingEpicrisisList : TTObjectCollection<ehrCreatingEpicrisis> { }
                    
        public class ChildehrCreatingEpicrisisCollection : TTObject.TTChildObjectCollection<ehrCreatingEpicrisis>
        {
            public ChildehrCreatingEpicrisisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrCreatingEpicrisisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Özgeçmiş
    /// </summary>
        public object AutoBiography
        {
            get { return (object)this["AUTOBIOGRAPHY"]; }
            set { this["AUTOBIOGRAPHY"] = value; }
        }

    /// <summary>
    /// Yakınmalar ve Öykü
    /// </summary>
        public object ComplaintAndStory
        {
            get { return (object)this["COMPLAINTANDSTORY"]; }
            set { this["COMPLAINTANDSTORY"] = value; }
        }

    /// <summary>
    /// Fizik Muayene
    /// </summary>
        public object PhysicalExamination
        {
            get { return (object)this["PHYSICALEXAMINATION"]; }
            set { this["PHYSICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// İşlemler
    /// </summary>
        public object Procedure
        {
            get { return (object)this["PROCEDURE"]; }
            set { this["PROCEDURE"] = value; }
        }

    /// <summary>
    /// Öneriler
    /// </summary>
        public object Suggestion
        {
            get { return (object)this["SUGGESTION"]; }
            set { this["SUGGESTION"] = value; }
        }

        protected ehrCreatingEpicrisis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrCreatingEpicrisis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrCreatingEpicrisis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrCreatingEpicrisis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrCreatingEpicrisis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRCREATINGEPICRISIS", dataRow) { }
        protected ehrCreatingEpicrisis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRCREATINGEPICRISIS", dataRow, isImported) { }
        public ehrCreatingEpicrisis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrCreatingEpicrisis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrCreatingEpicrisis() : base() { }

    }
}