
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialDocumentation")] 

    /// <summary>
    /// Malzeme Dökümantasyonu
    /// </summary>
    public  partial class MaterialDocumentation : TTObject
    {
        public class MaterialDocumentationList : TTObjectCollection<MaterialDocumentation> { }
                    
        public class ChildMaterialDocumentationCollection : TTObject.TTChildObjectCollection<MaterialDocumentation>
        {
            public ChildMaterialDocumentationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialDocumentationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dosya Adı
    /// </summary>
        public string FileName
        {
            get { return (string)this["FILENAME"]; }
            set { this["FILENAME"] = value; }
        }

    /// <summary>
    /// Dosya
    /// </summary>
        public object File
        {
            get { return (object)this["FILE"]; }
            set { this["FILE"] = value; }
        }

    /// <summary>
    /// Yüklenme Tarihi
    /// </summary>
        public DateTime? FileUpdateDate
        {
            get { return (DateTime?)this["FILEUPDATEDATE"]; }
            set { this["FILEUPDATEDATE"] = value; }
        }

        public MaterialDocumentType? MaterialDocumentType
        {
            get { return (MaterialDocumentType?)(int?)this["MATERIALDOCUMENTTYPE"]; }
            set { this["MATERIALDOCUMENTTYPE"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialDocumentation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialDocumentation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialDocumentation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialDocumentation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialDocumentation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALDOCUMENTATION", dataRow) { }
        protected MaterialDocumentation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALDOCUMENTATION", dataRow, isImported) { }
        public MaterialDocumentation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialDocumentation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialDocumentation() : base() { }

    }
}