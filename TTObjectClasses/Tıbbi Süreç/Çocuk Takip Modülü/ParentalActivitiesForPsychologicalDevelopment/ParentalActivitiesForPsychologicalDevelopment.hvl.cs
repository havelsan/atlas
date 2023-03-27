
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ParentalActivitiesForPsychologicalDevelopment")] 

    public  partial class ParentalActivitiesForPsychologicalDevelopment : TTObject
    {
        public class ParentalActivitiesForPsychologicalDevelopmentList : TTObjectCollection<ParentalActivitiesForPsychologicalDevelopment> { }
                    
        public class ChildParentalActivitiesForPsychologicalDevelopmentCollection : TTObject.TTChildObjectCollection<ParentalActivitiesForPsychologicalDevelopment>
        {
            public ChildParentalActivitiesForPsychologicalDevelopmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildParentalActivitiesForPsychologicalDevelopmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bebeğe / Çocuğa kitap okuma
    /// </summary>
        public bool? Reading
        {
            get { return (bool?)this["READING"]; }
            set { this["READING"] = value; }
        }

    /// <summary>
    /// Bebeğe / çocuğa masal anlatma
    /// </summary>
        public bool? Storytelling
        {
            get { return (bool?)this["STORYTELLING"]; }
            set { this["STORYTELLING"] = value; }
        }

    /// <summary>
    /// Bebeğe / çocuğa ninni, şarkı söyleme
    /// </summary>
        public bool? Singing
        {
            get { return (bool?)this["SINGING"]; }
            set { this["SINGING"] = value; }
        }

    /// <summary>
    /// Bebekle / çocukla ev dışında zaman geçirme
    /// </summary>
        public bool? OutsideActivities
        {
            get { return (bool?)this["OUTSIDEACTIVITIES"]; }
            set { this["OUTSIDEACTIVITIES"] = value; }
        }

    /// <summary>
    /// Bebekle / çocukla konuşma
    /// </summary>
        public bool? Talking
        {
            get { return (bool?)this["TALKING"]; }
            set { this["TALKING"] = value; }
        }

    /// <summary>
    /// Bebekle / çocukla oyun oynama
    /// </summary>
        public bool? Playtime
        {
            get { return (bool?)this["PLAYTIME"]; }
            set { this["PLAYTIME"] = value; }
        }

    /// <summary>
    /// Düzenli olarak yalnızca bebeğe / çocuğa yönelik zaman ayırma
    /// </summary>
        public bool? RegularBondingTime
        {
            get { return (bool?)this["REGULARBONDINGTIME"]; }
            set { this["REGULARBONDINGTIME"] = value; }
        }

    /// <summary>
    /// Yok
    /// </summary>
        public bool? None
        {
            get { return (bool?)this["NONE"]; }
            set { this["NONE"] = value; }
        }

    /// <summary>
    /// Diğer
    /// </summary>
        public bool? Other
        {
            get { return (bool?)this["OTHER"]; }
            set { this["OTHER"] = value; }
        }

        public ChildGrowthVisits ChildGrowthVisits
        {
            get { return (ChildGrowthVisits)((ITTObject)this).GetParent("CHILDGROWTHVISITS"); }
            set { this["CHILDGROWTHVISITS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri SKRSEbeveynPsikoGlsmDestkAktv
        {
            get { return (SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri)((ITTObject)this).GetParent("SKRSEBEVEYNPSIKOGLSMDESTKAKTV"); }
            set { this["SKRSEBEVEYNPSIKOGLSMDESTKAKTV"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ParentalActivitiesForPsychologicalDevelopment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ParentalActivitiesForPsychologicalDevelopment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ParentalActivitiesForPsychologicalDevelopment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ParentalActivitiesForPsychologicalDevelopment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ParentalActivitiesForPsychologicalDevelopment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PARENTALACTIVITIESFORPSYCHOLOGICALDEVELOPMENT", dataRow) { }
        protected ParentalActivitiesForPsychologicalDevelopment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PARENTALACTIVITIESFORPSYCHOLOGICALDEVELOPMENT", dataRow, isImported) { }
        public ParentalActivitiesForPsychologicalDevelopment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ParentalActivitiesForPsychologicalDevelopment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ParentalActivitiesForPsychologicalDevelopment() : base() { }

    }
}