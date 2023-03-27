
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Folder")] 

    public  partial class Folder : TTObject
    {
        public class FolderList : TTObjectCollection<Folder> { }
                    
        public class ChildFolderCollection : TTObject.TTChildObjectCollection<Folder>
        {
            public ChildFolderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFolderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? x
        {
            get { return (int?)this["X"]; }
            set { this["X"] = value; }
        }

    /// <summary>
    /// RTF2 idi
    /// </summary>
        public object RTF3
        {
            get { return (object)this["RTF3"]; }
            set { this["RTF3"] = value; }
        }

    /// <summary>
    /// RTF3 idi
    /// </summary>
        public object RTF
        {
            get { return (object)this["RTF"]; }
            set { this["RTF"] = value; }
        }

        public object RTF4
        {
            get { return (object)this["RTF4"]; }
            set { this["RTF4"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// TestID
    /// </summary>
        public Guid? TestID
        {
            get { return (Guid?)this["TESTID"]; }
            set { this["TESTID"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public int? Size
        {
            get { return (int?)this["SIZE"]; }
            set { this["SIZE"] = value; }
        }

    /// <summary>
    /// RTF idi
    /// </summary>
        public object RTF2
        {
            get { return (object)this["RTF2"]; }
            set { this["RTF2"] = value; }
        }

        public object Picture
        {
            get { return (object)this["PICTURE"]; }
            set { this["PICTURE"] = value; }
        }

        public Folder ParentFolder
        {
            get { return (Folder)((ITTObject)this).GetParent("PARENTFOLDER"); }
            set { this["PARENTFOLDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFilesCollection()
        {
            _Files = new FolderFile.ChildFolderFileCollection(this, new Guid("ac0f2f12-20b3-4312-91d2-2e9ac5bfefb6"));
            ((ITTChildObjectCollection)_Files).GetChildren();
        }

        protected FolderFile.ChildFolderFileCollection _Files = null;
    /// <summary>
    /// Child collection for Folder
    /// </summary>
        public FolderFile.ChildFolderFileCollection Files
        {
            get
            {
                if (_Files == null)
                    CreateFilesCollection();
                return _Files;
            }
        }

        virtual protected void CreateChildFoldersCollection()
        {
            _ChildFolders = new Folder.ChildFolderCollection(this, new Guid("babee1fa-8e5c-45f1-856d-bd52a1efccc5"));
            ((ITTChildObjectCollection)_ChildFolders).GetChildren();
        }

        protected Folder.ChildFolderCollection _ChildFolders = null;
        public Folder.ChildFolderCollection ChildFolders
        {
            get
            {
                if (_ChildFolders == null)
                    CreateChildFoldersCollection();
                return _ChildFolders;
            }
        }

        protected Folder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Folder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Folder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Folder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Folder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FOLDER", dataRow) { }
        protected Folder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FOLDER", dataRow, isImported) { }
        public Folder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Folder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Folder() : base() { }

    }
}