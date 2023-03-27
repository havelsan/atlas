
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActiveIngredientDetail")] 

    public  partial class ActiveIngredientDetail : TTObject
    {
        public class ActiveIngredientDetailList : TTObjectCollection<ActiveIngredientDetail> { }
                    
        public class ChildActiveIngredientDetailCollection : TTObject.TTChildObjectCollection<ActiveIngredientDetail>
        {
            public ChildActiveIngredientDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActiveIngredientDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? Sex
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

    /// <summary>
    /// Maximum Doz
    /// </summary>
        public double? MaxDose
        {
            get { return (double?)this["MAXDOSE"]; }
            set { this["MAXDOSE"] = value; }
        }

    /// <summary>
    /// Başlangıç Yaşı
    /// </summary>
        public int? StartingAge
        {
            get { return (int?)this["STARTINGAGE"]; }
            set { this["STARTINGAGE"] = value; }
        }

    /// <summary>
    /// Bitiş Yaşı
    /// </summary>
        public int? EndAge
        {
            get { return (int?)this["ENDAGE"]; }
            set { this["ENDAGE"] = value; }
        }

        public UnitDefinition MaxDoseUnit
        {
            get { return (UnitDefinition)((ITTObject)this).GetParent("MAXDOSEUNIT"); }
            set { this["MAXDOSEUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ActiveIngredientDefinition ActiveIngredient
        {
            get { return (ActiveIngredientDefinition)((ITTObject)this).GetParent("ACTIVEINGREDIENT"); }
            set { this["ACTIVEINGREDIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ActiveIngredientDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActiveIngredientDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActiveIngredientDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActiveIngredientDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActiveIngredientDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIVEINGREDIENTDETAIL", dataRow) { }
        protected ActiveIngredientDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIVEINGREDIENTDETAIL", dataRow, isImported) { }
        public ActiveIngredientDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActiveIngredientDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActiveIngredientDetail() : base() { }

    }
}