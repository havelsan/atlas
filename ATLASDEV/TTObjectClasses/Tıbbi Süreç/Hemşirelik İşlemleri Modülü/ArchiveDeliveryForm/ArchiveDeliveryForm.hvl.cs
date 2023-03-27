
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ArchiveDeliveryForm")] 

    /// <summary>
    /// Hasta Teslim Formu
    /// </summary>
    public  partial class ArchiveDeliveryForm : TTObject
    {
        public class ArchiveDeliveryFormList : TTObjectCollection<ArchiveDeliveryForm> { }
                    
        public class ChildArchiveDeliveryFormCollection : TTObject.TTChildObjectCollection<ArchiveDeliveryForm>
        {
            public ChildArchiveDeliveryFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildArchiveDeliveryFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ArchiveDeliveryForm> GetArchiveDeliveryFormBySubepisodeID(TTObjectContext objectContext, Guid SUBEPISODEID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ARCHIVEDELIVERYFORM"].QueryDefs["GetArchiveDeliveryFormBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return ((ITTQuery)objectContext).QueryObjects<ArchiveDeliveryForm>(queryDef, paramList);
        }

    /// <summary>
    /// SubepisodeID
    /// </summary>
        public Guid? SubepisodeID
        {
            get { return (Guid?)this["SUBEPISODEID"]; }
            set { this["SUBEPISODEID"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Teslim Alan
    /// </summary>
        public ResUser Recipient
        {
            get { return (ResUser)((ITTObject)this).GetParent("RECIPIENT"); }
            set { this["RECIPIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Teslim Eden
    /// </summary>
        public ResUser Deliverer
        {
            get { return (ResUser)((ITTObject)this).GetParent("DELIVERER"); }
            set { this["DELIVERER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateArchiveDeliveryFormDetailsCollection()
        {
            _ArchiveDeliveryFormDetails = new ArchiveDeliveryFormDetails.ChildArchiveDeliveryFormDetailsCollection(this, new Guid("eb6eafe3-4221-451d-8226-b24cd40d497c"));
            ((ITTChildObjectCollection)_ArchiveDeliveryFormDetails).GetChildren();
        }

        protected ArchiveDeliveryFormDetails.ChildArchiveDeliveryFormDetailsCollection _ArchiveDeliveryFormDetails = null;
        public ArchiveDeliveryFormDetails.ChildArchiveDeliveryFormDetailsCollection ArchiveDeliveryFormDetails
        {
            get
            {
                if (_ArchiveDeliveryFormDetails == null)
                    CreateArchiveDeliveryFormDetailsCollection();
                return _ArchiveDeliveryFormDetails;
            }
        }

        protected ArchiveDeliveryForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ArchiveDeliveryForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ArchiveDeliveryForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ArchiveDeliveryForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ArchiveDeliveryForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARCHIVEDELIVERYFORM", dataRow) { }
        protected ArchiveDeliveryForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARCHIVEDELIVERYFORM", dataRow, isImported) { }
        public ArchiveDeliveryForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ArchiveDeliveryForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ArchiveDeliveryForm() : base() { }

    }
}