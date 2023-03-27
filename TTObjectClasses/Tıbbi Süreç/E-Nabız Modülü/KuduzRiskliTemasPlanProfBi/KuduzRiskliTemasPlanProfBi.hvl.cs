
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KuduzRiskliTemasPlanProfBi")] 

    /// <summary>
    /// Kuduz Riskli Temas Veri Seti Kişiye Planlanan Kuduz Profilaksisi Bilgisi
    /// </summary>
    public  partial class KuduzRiskliTemasPlanProfBi : TTObject
    {
        public class KuduzRiskliTemasPlanProfBiList : TTObjectCollection<KuduzRiskliTemasPlanProfBi> { }
                    
        public class ChildKuduzRiskliTemasPlanProfBiCollection : TTObject.TTChildObjectCollection<KuduzRiskliTemasPlanProfBi>
        {
            public ChildKuduzRiskliTemasPlanProfBiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKuduzRiskliTemasPlanProfBiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSKisiyePlanlananKuduzProfilaksisi SKRSKisiyePlanKuduzProfilaksi
        {
            get { return (SKRSKisiyePlanlananKuduzProfilaksisi)((ITTObject)this).GetParent("SKRSKISIYEPLANKUDUZPROFILAKSI"); }
            set { this["SKRSKISIYEPLANKUDUZPROFILAKSI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KuduzRiskliTemasVeriSeti KuduzRiskliTemasVeriSeti
        {
            get { return (KuduzRiskliTemasVeriSeti)((ITTObject)this).GetParent("KUDUZRISKLITEMASVERISETI"); }
            set { this["KUDUZRISKLITEMASVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KuduzRiskliTemasPlanProfBi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KuduzRiskliTemasPlanProfBi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KuduzRiskliTemasPlanProfBi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KuduzRiskliTemasPlanProfBi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KuduzRiskliTemasPlanProfBi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KUDUZRISKLITEMASPLANPROFBI", dataRow) { }
        protected KuduzRiskliTemasPlanProfBi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KUDUZRISKLITEMASPLANPROFBI", dataRow, isImported) { }
        public KuduzRiskliTemasPlanProfBi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KuduzRiskliTemasPlanProfBi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KuduzRiskliTemasPlanProfBi() : base() { }

    }
}