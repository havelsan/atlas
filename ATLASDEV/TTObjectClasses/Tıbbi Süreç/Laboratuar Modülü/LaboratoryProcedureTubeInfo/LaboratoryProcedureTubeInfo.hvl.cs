
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryProcedureTubeInfo")] 

    public  partial class LaboratoryProcedureTubeInfo : TTObject
    {
        public class LaboratoryProcedureTubeInfoList : TTObjectCollection<LaboratoryProcedureTubeInfo> { }
                    
        public class ChildLaboratoryProcedureTubeInfoCollection : TTObject.TTChildObjectCollection<LaboratoryProcedureTubeInfo>
        {
            public ChildLaboratoryProcedureTubeInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryProcedureTubeInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// BarkodID ye gore laboratuvar procedure tube bilgisini doner
    /// </summary>
        public static BindingList<LaboratoryProcedureTubeInfo> GetLabProcedureTubeByContainerID(TTObjectContext objectContext, long CONTAINERID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYPROCEDURETUBEINFO"].QueryDefs["GetLabProcedureTubeByContainerID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CONTAINERID", CONTAINERID);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryProcedureTubeInfo>(queryDef, paramList);
        }

    /// <summary>
    /// İstek Kabul Tarihi (tüp bilgilerinde de tutuldu)
    /// </summary>
        public DateTime? RequestAcceptionDate
        {
            get { return (DateTime?)this["REQUESTACCEPTIONDATE"]; }
            set { this["REQUESTACCEPTIONDATE"] = value; }
        }

    /// <summary>
    /// Barkod Tipi
    /// </summary>
        public string BarcodeType
        {
            get { return (string)this["BARCODETYPE"]; }
            set { this["BARCODETYPE"] = value; }
        }

        public long? SpecimenID
        {
            get { return (long?)this["SPECIMENID"]; }
            set { this["SPECIMENID"] = value; }
        }

    /// <summary>
    /// BarcodeID
    /// </summary>
        public long? ContainerID
        {
            get { return (long?)this["CONTAINERID"]; }
            set { this["CONTAINERID"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string FromResourceName
        {
            get { return (string)this["FROMRESOURCENAME"]; }
            set { this["FROMRESOURCENAME"] = value; }
        }

        protected LaboratoryProcedureTubeInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryProcedureTubeInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryProcedureTubeInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryProcedureTubeInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryProcedureTubeInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYPROCEDURETUBEINFO", dataRow) { }
        protected LaboratoryProcedureTubeInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYPROCEDURETUBEINFO", dataRow, isImported) { }
        public LaboratoryProcedureTubeInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryProcedureTubeInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryProcedureTubeInfo() : base() { }

    }
}