
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingOrderTemplate")] 

    /// <summary>
    /// Hemşire Direktif Şablon
    /// </summary>
    public  partial class NursingOrderTemplate : TTObject
    {
        public class NursingOrderTemplateList : TTObjectCollection<NursingOrderTemplate> { }
                    
        public class ChildNursingOrderTemplateCollection : TTObject.TTChildObjectCollection<NursingOrderTemplate>
        {
            public ChildNursingOrderTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingOrderTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<NursingOrderTemplate> GetNursingOrderTemplateByResource(TTObjectContext objectContext, Guid RESOURCEID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGORDERTEMPLATE"].QueryDefs["GetNursingOrderTemplateByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEID", RESOURCEID);

            return ((ITTQuery)objectContext).QueryObjects<NursingOrderTemplate>(queryDef, paramList);
        }

    /// <summary>
    /// Şablon Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kaynak Bilgisi
    /// </summary>
        public Resource OwnerResource
        {
            get { return (Resource)((ITTObject)this).GetParent("OWNERRESOURCE"); }
            set { this["OWNERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOrderTemplateDetailsCollection()
        {
            _OrderTemplateDetails = new NursingOrderTemplateDetail.ChildNursingOrderTemplateDetailCollection(this, new Guid("8234451d-6594-42e9-847a-3c1391f363c1"));
            ((ITTChildObjectCollection)_OrderTemplateDetails).GetChildren();
        }

        protected NursingOrderTemplateDetail.ChildNursingOrderTemplateDetailCollection _OrderTemplateDetails = null;
        public NursingOrderTemplateDetail.ChildNursingOrderTemplateDetailCollection OrderTemplateDetails
        {
            get
            {
                if (_OrderTemplateDetails == null)
                    CreateOrderTemplateDetailsCollection();
                return _OrderTemplateDetails;
            }
        }

        protected NursingOrderTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingOrderTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingOrderTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingOrderTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingOrderTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGORDERTEMPLATE", dataRow) { }
        protected NursingOrderTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGORDERTEMPLATE", dataRow, isImported) { }
        public NursingOrderTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingOrderTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingOrderTemplate() : base() { }

    }
}