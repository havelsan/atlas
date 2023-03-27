
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
    /// <summary>
    /// SUT Kural Tanımları
    /// </summary>
    public partial class SohaRule : TTObject
    {
        protected override void PreInsert()
        {
            SohaRuleLog log = new SohaRuleLog(ObjectContext);
            log.LogType = OperationTypeEnum.Insert;
            log.User = Common.CurrentResource;
            log.LogDate = DateTime.Now;
            log.SohaRule = this;
            Common.SohaRuleRuleRepositoryChanged(ObjectContext, SohaRuleRepoTypeEnum.RuleRepository);
        }

        protected override void PreUpdate()
        {
            SohaRuleLog log = new SohaRuleLog(this.ObjectContext);
            if (IsDeleted == true)
                log.LogType = OperationTypeEnum.Delete;
            else
                log.LogType = OperationTypeEnum.Update;
            log.User = Common.CurrentResource;
            log.LogDate = DateTime.Now;
            log.SohaRule = this;
            Common.SohaRuleRuleRepositoryChanged(ObjectContext, SohaRuleRepoTypeEnum.RuleRepository);
        }
    }
}