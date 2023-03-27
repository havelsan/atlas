
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FolderFile")] 

    public  partial class FolderFile : TTObject
    {
        public class FolderFileList : TTObjectCollection<FolderFile> { }
                    
        public class ChildFolderFileCollection : TTObject.TTChildObjectCollection<FolderFile>
        {
            public ChildFolderFileCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFolderFileCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<FolderFile> GetFilesByFolder(TTObjectContext objectContext, Guid FOLDERID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLDERFILE"].QueryDefs["GetFilesByFolder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FOLDERID", FOLDERID);

            return ((ITTQuery)objectContext).QueryObjects<FolderFile>(queryDef, paramList);
        }

    /// <summary>
    /// Size
    /// </summary>
        public int? Size
        {
            get { return (int?)this["SIZE"]; }
            set { this["SIZE"] = value; }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public Currency? Fiyat
        {
            get { return (Currency?)this["FIYAT"]; }
            set { this["FIYAT"] = value; }
        }

        public Guid? GuidProp
        {
            get { return (Guid?)this["GUIDPROP"]; }
            set { this["GUIDPROP"] = value; }
        }

    /// <summary>
    /// BigFiyat
    /// </summary>
        public BigCurrency? BigFiyat
        {
            get { return (BigCurrency?)this["BIGFIYAT"]; }
            set { this["BIGFIYAT"] = value; }
        }

    /// <summary>
    /// Name
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Folder
    /// </summary>
        public Folder Folder
        {
            get { return (Folder)((ITTObject)this).GetParent("FOLDER"); }
            set { this["FOLDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ParentFile
    /// </summary>
        public FolderFile ParentFile
        {
            get { return (FolderFile)((ITTObject)this).GetParent("PARENTFILE"); }
            set { this["PARENTFILE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateChildFilesCollection()
        {
            _ChildFiles = new FolderFile.ChildFolderFileCollection(this, new Guid("58d3d0f6-9dea-4eac-93f0-99a2c4b2cce5"));
            ((ITTChildObjectCollection)_ChildFiles).GetChildren();
        }

        protected FolderFile.ChildFolderFileCollection _ChildFiles = null;
    /// <summary>
    /// Child collection for ParentFile
    /// </summary>
        public FolderFile.ChildFolderFileCollection ChildFiles
        {
            get
            {
                if (_ChildFiles == null)
                    CreateChildFilesCollection();
                return _ChildFiles;
            }
        }

        protected FolderFile(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FolderFile(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FolderFile(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FolderFile(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FolderFile(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FOLDERFILE", dataRow) { }
        protected FolderFile(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FOLDERFILE", dataRow, isImported) { }
        public FolderFile(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FolderFile(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FolderFile() : base() { }

    }
}