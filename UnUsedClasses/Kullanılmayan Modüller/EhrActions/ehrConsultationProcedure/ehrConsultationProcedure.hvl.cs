
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrConsultationProcedure")] 

    /// <summary>
    /// Konsültasyon
    /// </summary>
    public  partial class ehrConsultationProcedure : ehrSubactionFlowable
    {
        public class ehrConsultationProcedureList : TTObjectCollection<ehrConsultationProcedure> { }
                    
        public class ChildehrConsultationProcedureCollection : TTObject.TTChildObjectCollection<ehrConsultationProcedure>
        {
            public ChildehrConsultationProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrConsultationProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Konsültasyon Sonucu Ve Öneriler
    /// </summary>
        public object ConsultationResultAndOffers
        {
            get { return (object)this["CONSULTATIONRESULTANDOFFERS"]; }
            set { this["CONSULTATIONRESULTANDOFFERS"] = value; }
        }

    /// <summary>
    /// Konsültasyon Tarihi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

        protected ehrConsultationProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrConsultationProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrConsultationProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrConsultationProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrConsultationProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRCONSULTATIONPROCEDURE", dataRow) { }
        protected ehrConsultationProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRCONSULTATIONPROCEDURE", dataRow, isImported) { }
        public ehrConsultationProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrConsultationProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrConsultationProcedure() : base() { }

    }
}