
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrOrthesisProsthesis")] 

    /// <summary>
    /// Ortez Protez
    /// </summary>
    public  partial class ehrOrthesisProsthesis : ehrEpisodeAction
    {
        public class ehrOrthesisProsthesisList : TTObjectCollection<ehrOrthesisProsthesis> { }
                    
        public class ChildehrOrthesisProsthesisCollection : TTObject.TTChildObjectCollection<ehrOrthesisProsthesis>
        {
            public ChildehrOrthesisProsthesisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrOrthesisProsthesisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public object TotalDescription
        {
            get { return (object)this["TOTALDESCRIPTION"]; }
            set { this["TOTALDESCRIPTION"] = value; }
        }

    /// <summary>
    /// İstek Sebebi
    /// </summary>
        public object RequestReason
        {
            get { return (object)this["REQUESTREASON"]; }
            set { this["REQUESTREASON"] = value; }
        }

    /// <summary>
    /// Teknisyen Notu
    /// </summary>
        public string TechnicianNote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Baş Teknisyen Notu
    /// </summary>
        public string ChiefTechnicianNote
        {
            get { return (string)this["CHIEFTECHNICIANNOTE"]; }
            set { this["CHIEFTECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrOrthesisProsthesis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrOrthesisProsthesis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrOrthesisProsthesis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrOrthesisProsthesis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrOrthesisProsthesis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRORTHESISPROSTHESIS", dataRow) { }
        protected ehrOrthesisProsthesis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRORTHESISPROSTHESIS", dataRow, isImported) { }
        public ehrOrthesisProsthesis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrOrthesisProsthesis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrOrthesisProsthesis() : base() { }

    }
}