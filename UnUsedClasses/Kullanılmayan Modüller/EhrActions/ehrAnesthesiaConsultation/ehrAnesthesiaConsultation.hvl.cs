
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrAnesthesiaConsultation")] 

    /// <summary>
    /// Anestezi Konsültasyonu
    /// </summary>
    public  partial class ehrAnesthesiaConsultation : ehrEpisodeAction
    {
        public class ehrAnesthesiaConsultationList : TTObjectCollection<ehrAnesthesiaConsultation> { }
                    
        public class ChildehrAnesthesiaConsultationCollection : TTObject.TTChildObjectCollection<ehrAnesthesiaConsultation>
        {
            public ChildehrAnesthesiaConsultationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrAnesthesiaConsultationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Konsültasyon İstek Açıklaması
    /// </summary>
        public object ConsultationRequestNote
        {
            get { return (object)this["CONSULTATIONREQUESTNOTE"]; }
            set { this["CONSULTATIONREQUESTNOTE"] = value; }
        }

    /// <summary>
    /// Konsültasyon Tarihi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Anestezi Konsültasyon Bulguları
    /// </summary>
        public object ConsultationResult
        {
            get { return (object)this["CONSULTATIONRESULT"]; }
            set { this["CONSULTATIONRESULT"] = value; }
        }

        virtual protected void CreateehrAnesthesiaTechniqueGridsCollection()
        {
            _ehrAnesthesiaTechniqueGrids = new ehrAnesthesiaTechniqueGrid.ChildehrAnesthesiaTechniqueGridCollection(this, new Guid("fcd04c22-7f8f-4a24-bf76-032e74a0b960"));
            ((ITTChildObjectCollection)_ehrAnesthesiaTechniqueGrids).GetChildren();
        }

        protected ehrAnesthesiaTechniqueGrid.ChildehrAnesthesiaTechniqueGridCollection _ehrAnesthesiaTechniqueGrids = null;
        public ehrAnesthesiaTechniqueGrid.ChildehrAnesthesiaTechniqueGridCollection ehrAnesthesiaTechniqueGrids
        {
            get
            {
                if (_ehrAnesthesiaTechniqueGrids == null)
                    CreateehrAnesthesiaTechniqueGridsCollection();
                return _ehrAnesthesiaTechniqueGrids;
            }
        }

        protected ehrAnesthesiaConsultation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrAnesthesiaConsultation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrAnesthesiaConsultation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrAnesthesiaConsultation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrAnesthesiaConsultation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRANESTHESIACONSULTATION", dataRow) { }
        protected ehrAnesthesiaConsultation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRANESTHESIACONSULTATION", dataRow, isImported) { }
        public ehrAnesthesiaConsultation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrAnesthesiaConsultation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrAnesthesiaConsultation() : base() { }

    }
}