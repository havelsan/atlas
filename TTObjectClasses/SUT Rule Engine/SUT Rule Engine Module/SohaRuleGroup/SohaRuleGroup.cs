
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
    /// SUT Kural Grubu
    /// </summary>
    public  partial class SohaRuleGroup : TTObject
    {
        /// <summary>
        /// Kural grubu listesi i�erisinden istenilen tipteki grubu getirir, grup bulunamazsa hata d�nd�r�r. (SohaRuleGroup).
        /// </summary>
        /// <param name="sohaRuleGroupList">SohaRuleGroup listesi.</param>
        /// <param name="groupEnum">�stenilen grubun enum de�eri.</param>
        /// <returns>SohaRuleGroup</returns>
        public static SohaRuleGroup GetSohaRuleGroupByType(IEnumerable<SohaRuleGroup> sohaRuleGroupList, SohaRuleGroupEnum groupEnum)
        {
            SohaRuleGroup group = sohaRuleGroupList.FirstOrDefault(x => x.RuleGroupType == groupEnum);
            if (group != null)
                return group;
            else
                throw new TTException(Common.GetDescriptionOfDataTypeEnum(groupEnum) + "grubu mevcut de�il. Grup tan�m�n�n yap�lmas� gerekli.");
        }
    }
}