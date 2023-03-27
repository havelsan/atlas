
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebentureFollowExecutionList")] 

    /// <summary>
    /// Muhakemat Listesi
    /// </summary>
    public  partial class DebentureFollowExecutionList : TTObject
    {
        public class DebentureFollowExecutionListList : TTObjectCollection<DebentureFollowExecutionList> { }
                    
        public class ChildDebentureFollowExecutionListCollection : TTObject.TTChildObjectCollection<DebentureFollowExecutionList>
        {
            public ChildDebentureFollowExecutionListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebentureFollowExecutionListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Müdürlük
    /// </summary>
        public DebentureFollowManagementOfficeEnum? ManagementOffice
        {
            get { return (DebentureFollowManagementOfficeEnum?)(int?)this["MANAGEMENTOFFICE"]; }
            set { this["MANAGEMENTOFFICE"] = value; }
        }

    /// <summary>
    /// Muhakemat Tarihi
    /// </summary>
        public DateTime? ExecutionDate
        {
            get { return (DateTime?)this["EXECUTIONDATE"]; }
            set { this["EXECUTIONDATE"] = value; }
        }

    /// <summary>
    /// Raporlandı
    /// </summary>
        public bool? Reported
        {
            get { return (bool?)this["REPORTED"]; }
            set { this["REPORTED"] = value; }
        }

    /// <summary>
    /// Senetle İlişkisi
    /// </summary>
        public Debenture Debenture
        {
            get { return (Debenture)((ITTObject)this).GetParent("DEBENTURE"); }
            set { this["DEBENTURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Senet Takip İşlemiyle İlişkisi
    /// </summary>
        public DebentureFollow DebentureFollow
        {
            get { return (DebentureFollow)((ITTObject)this).GetParent("DEBENTUREFOLLOW"); }
            set { this["DEBENTUREFOLLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İlçeyle İlişkisi
    /// </summary>
        public TownDefinitions Town
        {
            get { return (TownDefinitions)((ITTObject)this).GetParent("TOWN"); }
            set { this["TOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Şehirle İlişkisi
    /// </summary>
        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta Dosyasıyla İlişkisi
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDebenturesCollection()
        {
            _Debentures = new Debenture.ChildDebentureCollection(this, new Guid("791e64c4-1464-4e3f-ad0a-95b45aaa2f4b"));
            ((ITTChildObjectCollection)_Debentures).GetChildren();
        }

        protected Debenture.ChildDebentureCollection _Debentures = null;
    /// <summary>
    /// Child collection for murat silinecek
    /// </summary>
        public Debenture.ChildDebentureCollection Debentures
        {
            get
            {
                if (_Debentures == null)
                    CreateDebenturesCollection();
                return _Debentures;
            }
        }

        protected DebentureFollowExecutionList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebentureFollowExecutionList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebentureFollowExecutionList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebentureFollowExecutionList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebentureFollowExecutionList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREFOLLOWEXECUTIONLIST", dataRow) { }
        protected DebentureFollowExecutionList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREFOLLOWEXECUTIONLIST", dataRow, isImported) { }
        public DebentureFollowExecutionList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebentureFollowExecutionList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebentureFollowExecutionList() : base() { }

    }
}