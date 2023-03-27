
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSTitle")] 

    /// <summary>
    /// Ünvan
    /// </summary>
    public  partial class MBSTitle : TTObject
    {
        public class MBSTitleList : TTObjectCollection<MBSTitle> { }
                    
        public class ChildMBSTitleCollection : TTObject.TTChildObjectCollection<MBSTitle>
        {
            public ChildMBSTitleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSTitleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ek ders göstergesi ? Yüksek Öğretim
    /// </summary>
        public int? AdditionalLessonIndicator
        {
            get { return (int?)this["ADDITIONALLESSONINDICATOR"]; }
            set { this["ADDITIONALLESSONINDICATOR"] = value; }
        }

    /// <summary>
    /// YÖK Tazminat yüzdesi
    /// </summary>
        public int? YOKCompensationPercent
        {
            get { return (int?)this["YOKCOMPENSATIONPERCENT"]; }
            set { this["YOKCOMPENSATIONPERCENT"] = value; }
        }

    /// <summary>
    /// Ek ders göstergesi ? Orta Öğretim
    /// </summary>
        public int? AdditionalLessonIndMidClass
        {
            get { return (int?)this["ADDITIONALLESSONINDMIDCLASS"]; }
            set { this["ADDITIONALLESSONINDMIDCLASS"] = value; }
        }

    /// <summary>
    /// Ünvan
    /// </summary>
        public string Title
        {
            get { return (string)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

    /// <summary>
    /// Bülten kesintisi
    /// </summary>
        public double? BulletinReduction
        {
            get { return (double?)this["BULLETINREDUCTION"]; }
            set { this["BULLETINREDUCTION"] = value; }
        }

    /// <summary>
    /// Kurul kesintisi
    /// </summary>
        public double? CommitteeReduction
        {
            get { return (double?)this["COMMITTEEREDUCTION"]; }
            set { this["COMMITTEEREDUCTION"] = value; }
        }

        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSTitle(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSTitle(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSTitle(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSTitle(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSTitle(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSTITLE", dataRow) { }
        protected MBSTitle(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSTITLE", dataRow, isImported) { }
        public MBSTitle(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSTitle(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSTitle() : base() { }

    }
}