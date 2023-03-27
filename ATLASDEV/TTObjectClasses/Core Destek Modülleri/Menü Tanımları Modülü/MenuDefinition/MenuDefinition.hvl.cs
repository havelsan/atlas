
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MenuDefinition")] 

    public  partial class MenuDefinition : TerminologyManagerDef
    {
        public class MenuDefinitionList : TTObjectCollection<MenuDefinition> { }
                    
        public class ChildMenuDefinitionCollection : TTObject.TTChildObjectCollection<MenuDefinition>
        {
            public ChildMenuDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMenuDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MenuDefinition> GetMenuDefinition(TTObjectContext objectContext, string OBJECTDEFINITIONNAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MENUDEFINITION"].QueryDefs["GetMenuDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTDEFINITIONNAME", OBJECTDEFINITIONNAME);

            return ((ITTQuery)objectContext).QueryObjects<MenuDefinition>(queryDef, paramList);
        }

        public static BindingList<MenuDefinition> GetMainMenu(TTObjectContext objectContext, IList<int> MENUGROUP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MENUDEFINITION"].QueryDefs["GetMainMenu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MENUGROUP", MENUGROUP);

            return ((ITTQuery)objectContext).QueryObjects<MenuDefinition>(queryDef, paramList);
        }

        public static BindingList<MenuDefinition> GetChildMenu(TTObjectContext objectContext, string PARENTMENU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MENUDEFINITION"].QueryDefs["GetChildMenu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTMENU", PARENTMENU);

            return ((ITTQuery)objectContext).QueryObjects<MenuDefinition>(queryDef, paramList);
        }

        public static BindingList<MenuDefinition> GetAllMenuDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MENUDEFINITION"].QueryDefs["GetAllMenuDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<MenuDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Çalıştırılacak Nesne
    /// </summary>
        public string ObjectDefinitionName
        {
            get { return (string)this["OBJECTDEFINITIONNAME"]; }
            set { this["OBJECTDEFINITIONNAME"] = value; }
        }

    /// <summary>
    /// Sıra Nu.
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Giriş Adımı 
    /// </summary>
        public string EntryState
        {
            get { return (string)this["ENTRYSTATE"]; }
            set { this["ENTRYSTATE"] = value; }
        }

    /// <summary>
    /// Menü Grubu
    /// </summary>
        public MenuTypeEnum? MenuGroup
        {
            get { return (MenuTypeEnum?)(int?)this["MENUGROUP"]; }
            set { this["MENUGROUP"] = value; }
        }

        public string Caption_Shadow
        {
            get { return (string)this["CAPTION_SHADOW"]; }
        }

    /// <summary>
    /// Başlık
    /// </summary>
        public string Caption
        {
            get { return (string)this["CAPTION"]; }
            set { this["CAPTION"] = value; }
        }

    /// <summary>
    /// Çalışılacak Form
    /// </summary>
        public string UnboundFormName
        {
            get { return (string)this["UNBOUNDFORMNAME"]; }
            set { this["UNBOUNDFORMNAME"] = value; }
        }

    /// <summary>
    /// Menu Tanım Nu.
    /// </summary>
        public TTSequence MenuDefinitionNo
        {
            get { return GetSequence("MENUDEFINITIONNO"); }
        }

    /// <summary>
    /// Pasif
    /// </summary>
        public bool? IsDisabled
        {
            get { return (bool?)this["ISDISABLED"]; }
            set { this["ISDISABLED"] = value; }
        }

        public string IconPath
        {
            get { return (string)this["ICONPATH"]; }
            set { this["ICONPATH"] = value; }
        }

    /// <summary>
    /// Alt Menüler
    /// </summary>
        public MenuDefinition ParentMenu
        {
            get { return (MenuDefinition)((ITTObject)this).GetParent("PARENTMENU"); }
            set { this["PARENTMENU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateChildMenusCollection()
        {
            _ChildMenus = new MenuDefinition.ChildMenuDefinitionCollection(this, new Guid("0957a0cb-fc01-45a3-ba8c-4e5080705973"));
            ((ITTChildObjectCollection)_ChildMenus).GetChildren();
        }

        protected MenuDefinition.ChildMenuDefinitionCollection _ChildMenus = null;
    /// <summary>
    /// Child collection for Alt Menüler
    /// </summary>
        public MenuDefinition.ChildMenuDefinitionCollection ChildMenus
        {
            get
            {
                if (_ChildMenus == null)
                    CreateChildMenusCollection();
                return _ChildMenus;
            }
        }

        virtual protected void CreateNotIncludeSitesCollection()
        {
            _NotIncludeSites = new NotIncludeSites.ChildNotIncludeSitesCollection(this, new Guid("a05e1d07-4544-4413-8db2-d2cb52d962a5"));
            ((ITTChildObjectCollection)_NotIncludeSites).GetChildren();
        }

        protected NotIncludeSites.ChildNotIncludeSitesCollection _NotIncludeSites = null;
        public NotIncludeSites.ChildNotIncludeSitesCollection NotIncludeSites
        {
            get
            {
                if (_NotIncludeSites == null)
                    CreateNotIncludeSitesCollection();
                return _NotIncludeSites;
            }
        }

        protected MenuDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MenuDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MenuDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MenuDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MenuDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MENUDEFINITION", dataRow) { }
        protected MenuDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MENUDEFINITION", dataRow, isImported) { }
        public MenuDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MenuDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MenuDefinition() : base() { }

    }
}