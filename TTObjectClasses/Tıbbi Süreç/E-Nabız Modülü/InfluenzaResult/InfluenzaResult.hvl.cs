
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InfluenzaResult")] 

    /// <summary>
    /// Influenza Sonuş Ekranı
    /// </summary>
    public  partial class InfluenzaResult : TTObject
    {
        public class InfluenzaResultList : TTObjectCollection<InfluenzaResult> { }
                    
        public class ChildInfluenzaResultCollection : TTObject.TTChildObjectCollection<InfluenzaResult>
        {
            public ChildInfluenzaResultCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInfluenzaResultCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PositiveNegativeEnum? InfluenzaResultProp
        {
            get { return (PositiveNegativeEnum?)(int?)this["INFLUENZARESULTPROP"]; }
            set { this["INFLUENZARESULTPROP"] = value; }
        }

        public string ICD10Kodu
        {
            get { return (string)this["ICD10KODU"]; }
            set { this["ICD10KODU"] = value; }
        }

    /// <summary>
    /// Servisten dönen değerler
    /// </summary>
        public string IslemGuid
        {
            get { return (string)this["ISLEMGUID"]; }
            set { this["ISLEMGUID"] = value; }
        }

    /// <summary>
    /// Hata mesajı
    /// </summary>
        public string ErrorMessage
        {
            get { return (string)this["ERRORMESSAGE"]; }
            set { this["ERRORMESSAGE"] = value; }
        }

        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateEpisodeCollection()
        {
            _Episode = new Episode.ChildEpisodeCollection(this, new Guid("054723ef-0dc0-4a4e-b8f4-ad9b92274723"));
            ((ITTChildObjectCollection)_Episode).GetChildren();
        }

        protected Episode.ChildEpisodeCollection _Episode = null;
        public Episode.ChildEpisodeCollection Episode
        {
            get
            {
                if (_Episode == null)
                    CreateEpisodeCollection();
                return _Episode;
            }
        }

        protected InfluenzaResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InfluenzaResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InfluenzaResult(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InfluenzaResult(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InfluenzaResult(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INFLUENZARESULT", dataRow) { }
        protected InfluenzaResult(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INFLUENZARESULT", dataRow, isImported) { }
        public InfluenzaResult(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InfluenzaResult(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InfluenzaResult() : base() { }

    }
}