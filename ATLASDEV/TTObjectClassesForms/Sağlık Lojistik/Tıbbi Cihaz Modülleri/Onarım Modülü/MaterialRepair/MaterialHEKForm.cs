
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// HEK [Stok Numaralı]
    /// </summary>
    public partial class MaterialHEKForm : RepairBaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region MaterialHEKForm_PreScript
    base.PreScript();
            
            
            if (_MaterialRepair.RULHEKReasons.Count == 0)
            {
                IList reasons = _MaterialRepair.ObjectContext.QueryObjects("COUSESOFTHEHEKDEFINITION", string.Empty);
                foreach (CousesOfTheHekDefinition cousesOfTheHekDefinition in reasons)
                {
                    RULHEKReason rULHEKReason = _MaterialRepair.RULHEKReasons.AddNew();
                    rULHEKReason.CousesOfTheHekDefinition = cousesOfTheHekDefinition;
                    rULHEKReason.Check = false;
                }
            }
            if (_MaterialRepair.RepairHEKCommisionMembers.Count == 0)
            {
                RepairHEKCommisionMember mRepairHEKCommisionMember = _MaterialRepair.RepairHEKCommisionMembers.AddNew();
                mRepairHEKCommisionMember.CommisionOrderNo = 1;
                mRepairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.Member;

                mRepairHEKCommisionMember = _MaterialRepair.RepairHEKCommisionMembers.AddNew();
                mRepairHEKCommisionMember.CommisionOrderNo = 2;
                mRepairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.TechnicalMember;

                mRepairHEKCommisionMember = _MaterialRepair.RepairHEKCommisionMembers.AddNew();
                mRepairHEKCommisionMember.CommisionOrderNo = 3;
                mRepairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.TechnicalMember;

                mRepairHEKCommisionMember = _MaterialRepair.RepairHEKCommisionMembers.AddNew();
                mRepairHEKCommisionMember.CommisionOrderNo = 4;
                mRepairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.Chief;

                mRepairHEKCommisionMember = _MaterialRepair.RepairHEKCommisionMembers.AddNew();
                mRepairHEKCommisionMember.CommisionOrderNo = 5;
                mRepairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.Approval;

            }

            string description = "";
            string hekNedeni = "";
            string aciklama = "    Yukarıda marka modeli belirtilen cihaz, uzun süreli kullanımdan dolayı kullanıcı hatası olmaksızın normal aşınma ve yıpranma sonucu nitelik ve özelliklerini kaybetmiştir.\n Cihazın yapılan incelemesinde; ";
            string aciklama2 = " tespit edilmiştir. Cihazın mevcut durumu nedeniyle onarılmasının mümkün olmayacağı değerlendirilmiştir.\n   Cihazın eski model ve eski teknoloji ürünü olması nedeniyle yenileştirilmesi mümkün değildir.";
            string aciklama3 = "\n    Yukarıda belirtilen nedenlerden dolayı; MSY 59-2(A) XXXXXX Taşınır Mal Yönergesinin 5.ncü bölüm 1.inci maddesi I-";
            string aciklama4 = "  dolayı kayıt silme işlemine tabi tutulmasının uygun olacağı değerlendirilmiştir.";
            if (_MaterialRepair.HEKReportRepairDetail == null && _MaterialRepair.HEKReportDescription != null && _MaterialRepair.RepairNotes != null)
            {
                foreach (RULHEKReason rulHek in _MaterialRepair.RULHEKReasons)
                {
                    if (rulHek.Check == true)
                    {
                        hekNedeni = rulHek.CousesOfTheHekDefinition.Counter + " fıkrasında belirtildiği üzere " + rulHek.CousesOfTheHekDefinition.Description;
                        description = aciklama + TTObjectClasses.Common.GetTextOfRTFString(_MaterialRepair.HEKReportDescription) + aciklama2 + aciklama3 + hekNedeni + aciklama4;
                        _MaterialRepair.HEKReportRepairDetail = TTObjectClasses.Common.GetRTFOfTextString(description);
                        break;
                    }
                }
            }

            
            
            
            Currency totalCost = 0;
            Currency totalMaterialCost = 0;
            Currency labourCost = 0 ;
            if(_MaterialRepair.TotalWorkLoad != null && _MaterialRepair.UnitWorkLoadPrice != null)
                labourCost = (Currency)_MaterialRepair.TotalWorkLoad * (Currency)_MaterialRepair.UnitWorkLoadPrice;
            
            _MaterialRepair.LaborTotalCost = labourCost;
            foreach (NeededMaterials neededMaterial in _MaterialRepair.NeededMaterials)
            {
                totalMaterialCost = (Currency)totalMaterialCost + (Currency)neededMaterial.MaterialTotalPrice;
            }
            totalCost = totalMaterialCost + labourCost;
            _MaterialRepair.RepairTotalCost = totalCost;
#endregion MaterialHEKForm_PreScript

            }
                }
}