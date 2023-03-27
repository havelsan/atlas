
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
    public partial class SUTInstance : TTObject, ISUTInstance
    {
        #region Methods
        private ISUTEpisodeAction _sutEpisodeAction;
        public ISUTEpisodeAction GetSUTEpisodeAction()
        {
            return _sutEpisodeAction;
        }

        private ISUTRulableObject _sutRulableObject;
        public ISUTRulableObject GetSUTRulableObject()
        {
            return _sutRulableObject;
        }


        private double? _ruleAmount;
        public double? GetRuleAmount()
        {
            return _ruleAmount;
        }


        private DateTime? _ruleDate;
        public DateTime? GetRuleDate()
        {
            return _ruleDate;
        }

        private long? _doctorSpecialityCode;
        public long? GetDoctorSpecialityCode()
        {
            return _doctorSpecialityCode;
        }

        #endregion Methods

    }
}