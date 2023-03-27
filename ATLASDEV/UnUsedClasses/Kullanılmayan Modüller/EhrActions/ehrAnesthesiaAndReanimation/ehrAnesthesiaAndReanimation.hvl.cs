
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrAnesthesiaAndReanimation")] 

    /// <summary>
    /// Anestezi ve Reanimasyon
    /// </summary>
    public  partial class ehrAnesthesiaAndReanimation : ehrEpisodeAction
    {
        public class ehrAnesthesiaAndReanimationList : TTObjectCollection<ehrAnesthesiaAndReanimation> { }
                    
        public class ChildehrAnesthesiaAndReanimationCollection : TTObject.TTChildObjectCollection<ehrAnesthesiaAndReanimation>
        {
            public ChildehrAnesthesiaAndReanimationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrAnesthesiaAndReanimationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Anestezi Raporu
    /// </summary>
        public object AnesthesiaReport
        {
            get { return (object)this["ANESTHESIAREPORT"]; }
            set { this["ANESTHESIAREPORT"] = value; }
        }

    /// <summary>
    /// ASA
    /// </summary>
        public AnesthesiaASATypeEnum? ASAType
        {
            get { return (AnesthesiaASATypeEnum?)(int?)this["ASATYPE"]; }
            set { this["ASATYPE"] = value; }
        }

    /// <summary>
    /// Anestezi Başlama Tarihi
    /// </summary>
        public DateTime? AnesthesiaStartDateTime
        {
            get { return (DateTime?)this["ANESTHESIASTARTDATETIME"]; }
            set { this["ANESTHESIASTARTDATETIME"] = value; }
        }

    /// <summary>
    /// Anestezi Tekniği
    /// </summary>
        public AnesthesiaTechniqueEnum? AnesthesiaTechnique
        {
            get { return (AnesthesiaTechniqueEnum?)(int?)this["ANESTHESIATECHNIQUE"]; }
            set { this["ANESTHESIATECHNIQUE"] = value; }
        }

    /// <summary>
    /// Anestezi Bitiş Tarih
    /// </summary>
        public DateTime? AnesthesiaEndDateTime
        {
            get { return (DateTime?)this["ANESTHESIAENDDATETIME"]; }
            set { this["ANESTHESIAENDDATETIME"] = value; }
        }

        public ehrSurgery ehrMainSurgery
        {
            get { return (ehrSurgery)((ITTObject)this).GetParent("EHRMAINSURGERY"); }
            set { this["EHRMAINSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateehrSurgeriesCollection()
        {
            _ehrSurgeries = new ehrSurgery.ChildehrSurgeryCollection(this, new Guid("a6bf05ff-ece2-47a1-97ac-986504182389"));
            ((ITTChildObjectCollection)_ehrSurgeries).GetChildren();
        }

        protected ehrSurgery.ChildehrSurgeryCollection _ehrSurgeries = null;
    /// <summary>
    /// Child collection for Anestezi ve Reanimasyon İşlemi
    /// </summary>
        public ehrSurgery.ChildehrSurgeryCollection ehrSurgeries
        {
            get
            {
                if (_ehrSurgeries == null)
                    CreateehrSurgeriesCollection();
                return _ehrSurgeries;
            }
        }

        protected ehrAnesthesiaAndReanimation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrAnesthesiaAndReanimation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrAnesthesiaAndReanimation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrAnesthesiaAndReanimation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrAnesthesiaAndReanimation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRANESTHESIAANDREANIMATION", dataRow) { }
        protected ehrAnesthesiaAndReanimation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRANESTHESIAANDREANIMATION", dataRow, isImported) { }
        public ehrAnesthesiaAndReanimation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrAnesthesiaAndReanimation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrAnesthesiaAndReanimation() : base() { }

    }
}