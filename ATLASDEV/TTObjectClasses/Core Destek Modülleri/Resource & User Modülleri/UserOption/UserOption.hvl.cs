
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserOption")] 

    public  partial class UserOption : TTObject
    {
        public class UserOptionList : TTObjectCollection<UserOption> { }
                    
        public class ChildUserOptionCollection : TTObject.TTChildObjectCollection<UserOption>
        {
            public ChildUserOptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserOptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<UserOption> GetOption(TTObjectContext objectContext, string RESUSER, UserOptionType OPTIONTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USEROPTION"].QueryDefs["GetOption"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);
            paramList.Add("OPTIONTYPE", (int)OPTIONTYPE);

            return ((ITTQuery)objectContext).QueryObjects<UserOption>(queryDef, paramList);
        }

        public static BindingList<UserOption> GetSystemOption(TTObjectContext objectContext, UserOptionType OPTIONTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USEROPTION"].QueryDefs["GetSystemOption"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OPTIONTYPE", (int)OPTIONTYPE);

            return ((ITTQuery)objectContext).QueryObjects<UserOption>(queryDef, paramList);
        }

        public static BindingList<UserOption> GetAllSystemOptions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USEROPTION"].QueryDefs["GetAllSystemOptions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<UserOption>(queryDef, paramList);
        }

        public static BindingList<UserOption> GetCurrentUserSAllOptions(TTObjectContext objectContext, string RESUSER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USEROPTION"].QueryDefs["GetCurrentUserSAllOptions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);

            return ((ITTQuery)objectContext).QueryObjects<UserOption>(queryDef, paramList);
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
    /// Değer
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

    /// <summary>
    /// Değer
    /// </summary>
        public object OptionValue
        {
            get { return (object)this["OPTIONVALUE"]; }
            set { this["OPTIONVALUE"] = value; }
        }

    /// <summary>
    /// Soru Tipi
    /// </summary>
        public QuestionTypeEnum? QuestionType
        {
            get { return (QuestionTypeEnum?)(int?)this["QUESTIONTYPE"]; }
            set { this["QUESTIONTYPE"] = value; }
        }

    /// <summary>
    /// Seçenek Türü
    /// </summary>
        public UserOptionType? OptionType
        {
            get { return (UserOptionType?)(int?)this["OPTIONTYPE"]; }
            set { this["OPTIONTYPE"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UserOption(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserOption(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserOption(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserOption(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserOption(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USEROPTION", dataRow) { }
        protected UserOption(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USEROPTION", dataRow, isImported) { }
        public UserOption(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserOption(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserOption() : base() { }

    }
}