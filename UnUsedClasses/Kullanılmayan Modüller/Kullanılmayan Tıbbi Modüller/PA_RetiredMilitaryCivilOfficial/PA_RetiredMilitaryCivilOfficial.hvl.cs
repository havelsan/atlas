
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_RetiredMilitaryCivilOfficial")] 

    /// <summary>
    /// Emekli Sivil Memur Kabulü
    /// </summary>
    public  partial class PA_RetiredMilitaryCivilOfficial : PA_MilitaryRetired
    {
        public class PA_RetiredMilitaryCivilOfficialList : TTObjectCollection<PA_RetiredMilitaryCivilOfficial> { }
                    
        public class ChildPA_RetiredMilitaryCivilOfficialCollection : TTObject.TTChildObjectCollection<PA_RetiredMilitaryCivilOfficial>
        {
            public ChildPA_RetiredMilitaryCivilOfficialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_RetiredMilitaryCivilOfficialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("2a43b5c5-e070-4e5f-a792-63e6cdf9e97c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe3624fd-600f-44e6-a59b-87ff7a9d2532"); } }
        }

    /// <summary>
    /// Sivil Memur Statüsü
    /// </summary>
        public MilitaryCivilOfficalStatusEnum? MilitaryCivilOfficeStatus
        {
            get { return (MilitaryCivilOfficalStatusEnum?)(int?)this["MILITARYCIVILOFFICESTATUS"]; }
            set { this["MILITARYCIVILOFFICESTATUS"] = value; }
        }

        protected PA_RetiredMilitaryCivilOfficial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_RetiredMilitaryCivilOfficial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_RetiredMilitaryCivilOfficial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_RetiredMilitaryCivilOfficial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_RetiredMilitaryCivilOfficial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_RETIREDMILITARYCIVILOFFICIAL", dataRow) { }
        protected PA_RetiredMilitaryCivilOfficial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_RETIREDMILITARYCIVILOFFICIAL", dataRow, isImported) { }
        public PA_RetiredMilitaryCivilOfficial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_RetiredMilitaryCivilOfficial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_RetiredMilitaryCivilOfficial() : base() { }

    }
}