
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ICF")] 

    /// <summary>
    /// ICF Kodlama
    /// </summary>
    public  partial class ICF : TTObject
    {
        public class ICFList : TTObjectCollection<ICF> { }
                    
        public class ChildICFCollection : TTObject.TTChildObjectCollection<ICF>
        {
            public ChildICFCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildICFCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// ICF Kodu
    /// </summary>
        public string ICFCode
        {
            get { return (string)this["ICFCODE"]; }
            set { this["ICFCODE"] = value; }
        }

    /// <summary>
    /// Türkçe Başlık
    /// </summary>
        public string TurkishTitle
        {
            get { return (string)this["TURKISHTITLE"]; }
            set { this["TURKISHTITLE"] = value; }
        }

    /// <summary>
    /// Türkçe Açıklama
    /// </summary>
        public string TurkishDescription
        {
            get { return (string)this["TURKISHDESCRIPTION"]; }
            set { this["TURKISHDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kapsadıkları(Türkçe)
    /// </summary>
        public string TurkishInclusions
        {
            get { return (string)this["TURKISHINCLUSIONS"]; }
            set { this["TURKISHINCLUSIONS"] = value; }
        }

    /// <summary>
    /// Kapsamadıkları(Türkçe)
    /// </summary>
        public string TurkishExclusions
        {
            get { return (string)this["TURKISHEXCLUSIONS"]; }
            set { this["TURKISHEXCLUSIONS"] = value; }
        }

    /// <summary>
    /// İngilizce Başlık
    /// </summary>
        public string EnglishTitle
        {
            get { return (string)this["ENGLISHTITLE"]; }
            set { this["ENGLISHTITLE"] = value; }
        }

    /// <summary>
    /// EnglishDescription
    /// </summary>
        public string EnglishDescription
        {
            get { return (string)this["ENGLISHDESCRIPTION"]; }
            set { this["ENGLISHDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kapsamadıkları(İngilizce)
    /// </summary>
        public string EnglishExclusions
        {
            get { return (string)this["ENGLISHEXCLUSIONS"]; }
            set { this["ENGLISHEXCLUSIONS"] = value; }
        }

    /// <summary>
    /// Kapsadıkları(İngilizce)
    /// </summary>
        public string EnglishInclusions
        {
            get { return (string)this["ENGLISHINCLUSIONS"]; }
            set { this["ENGLISHINCLUSIONS"] = value; }
        }

        protected ICF(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ICF(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ICF(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ICF(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ICF(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ICF", dataRow) { }
        protected ICF(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ICF", dataRow, isImported) { }
        public ICF(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ICF(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ICF() : base() { }

    }
}