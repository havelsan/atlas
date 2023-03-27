
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TraditionalMedicine")] 

    /// <summary>
    /// Traditional and complementary medicine object
    /// </summary>
    public  partial class TraditionalMedicine : SpecialityBasedObject
    {
        public class TraditionalMedicineList : TTObjectCollection<TraditionalMedicine> { }
                    
        public class ChildTraditionalMedicineCollection : TTObject.TTChildObjectCollection<TraditionalMedicine>
        {
            public ChildTraditionalMedicineCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTraditionalMedicineCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Getat Tedavi Sonucu
    /// </summary>
        public SKRSGETATTedaviSonucu GetatExaminationResult
        {
            get { return (SKRSGETATTedaviSonucu)((ITTObject)this).GetParent("GETATEXAMINATIONRESULT"); }
            set { this["GETATEXAMINATIONRESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Getat Uygulama Birimi
    /// </summary>
        public SKRSGETATUygulamaBirimi GetatApplicationUnit
        {
            get { return (SKRSGETATUygulamaBirimi)((ITTObject)this).GetParent("GETATAPPLICATIONUNIT"); }
            set { this["GETATAPPLICATIONUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Getat Uygulama Türü 
    /// </summary>
        public SKRSGETATUygulamaTuru GetatApplicationType
        {
            get { return (SKRSGETATUygulamaTuru)((ITTObject)this).GetParent("GETATAPPLICATIONTYPE"); }
            set { this["GETATAPPLICATIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTraditionalMedAppCasesCollection()
        {
            _TraditionalMedAppCases = new TradititionalMedAppCases.ChildTradititionalMedAppCasesCollection(this, new Guid("a02ab959-7b97-4d41-865b-fdef928efd37"));
            ((ITTChildObjectCollection)_TraditionalMedAppCases).GetChildren();
        }

        protected TradititionalMedAppCases.ChildTradititionalMedAppCasesCollection _TraditionalMedAppCases = null;
    /// <summary>
    /// Child collection for Traditional Medicine
    /// </summary>
        public TradititionalMedAppCases.ChildTradititionalMedAppCasesCollection TraditionalMedAppCases
        {
            get
            {
                if (_TraditionalMedAppCases == null)
                    CreateTraditionalMedAppCasesCollection();
                return _TraditionalMedAppCases;
            }
        }

        virtual protected void CreateTraditionalMedAppRegionCollection()
        {
            _TraditionalMedAppRegion = new TraditionalMedAppRegion.ChildTraditionalMedAppRegionCollection(this, new Guid("24a05da6-2404-48b8-b9c4-a2b65f554b65"));
            ((ITTChildObjectCollection)_TraditionalMedAppRegion).GetChildren();
        }

        protected TraditionalMedAppRegion.ChildTraditionalMedAppRegionCollection _TraditionalMedAppRegion = null;
    /// <summary>
    /// Child collection for Traditional Medicine
    /// </summary>
        public TraditionalMedAppRegion.ChildTraditionalMedAppRegionCollection TraditionalMedAppRegion
        {
            get
            {
                if (_TraditionalMedAppRegion == null)
                    CreateTraditionalMedAppRegionCollection();
                return _TraditionalMedAppRegion;
            }
        }

        protected TraditionalMedicine(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TraditionalMedicine(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TraditionalMedicine(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TraditionalMedicine(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TraditionalMedicine(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRADITIONALMEDICINE", dataRow) { }
        protected TraditionalMedicine(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRADITIONALMEDICINE", dataRow, isImported) { }
        public TraditionalMedicine(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TraditionalMedicine(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TraditionalMedicine() : base() { }

    }
}