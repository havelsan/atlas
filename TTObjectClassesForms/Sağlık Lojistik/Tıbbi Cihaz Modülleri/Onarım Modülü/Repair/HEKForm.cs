
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
    /// HEK'e Ayırma
    /// </summary>
    public partial class HEKForm : RepairBaseForm
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
#region HEKForm_PreScript
    base.PreScript();

            Currency totalCost = 0;
            Currency totalMaterialCost = 0;
            Currency labourCost = 0;
            if(_Repair.TotalWorkLoad != null && _Repair.UnitWorkLoadPrice != null)
                labourCost = (Currency)_Repair.TotalWorkLoad * (Currency)_Repair.UnitWorkLoadPrice;
            _Repair.LaborTotalCost = labourCost;
            foreach (NeededMaterials neededMaterial in _Repair.NeededMaterials)
            {
                totalMaterialCost = (Currency)totalMaterialCost + (Currency)neededMaterial.MaterialTotalPrice;
            }
            totalCost = totalMaterialCost + labourCost;
            _Repair.RepairTotalCost = totalCost;

            if (_Repair.MaterialPurchasePrice == null)
                _Repair.MaterialPurchasePrice = _Repair.FindPurchasePrice();
            
            
            
            if (_Repair.RULHEKReasons.Count == 0)
            {
                IList reasons = _Repair.ObjectContext.QueryObjects("COUSESOFTHEHEKDEFINITION", string.Empty);
                foreach (CousesOfTheHekDefinition cousesOfTheHekDefinition in reasons)
                {
                    RULHEKReason rULHEKReason = _Repair.RULHEKReasons.AddNew();
                    rULHEKReason.CousesOfTheHekDefinition = cousesOfTheHekDefinition;
                    rULHEKReason.Check = false;
                }
            }


            if(_Repair.RepairHEKCommisionMembers.Count == 0)
            {
                RepairHEKCommisionMember repairHEKCommisionMember = _Repair.RepairHEKCommisionMembers.AddNew();
                repairHEKCommisionMember.CommisionOrderNo = 1;
                repairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.Member;

                repairHEKCommisionMember = _Repair.RepairHEKCommisionMembers.AddNew();
                repairHEKCommisionMember.CommisionOrderNo = 2;
                repairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.TechnicalMember;

                repairHEKCommisionMember = _Repair.RepairHEKCommisionMembers.AddNew();
                repairHEKCommisionMember.CommisionOrderNo = 3;
                repairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.TechnicalMember;

                repairHEKCommisionMember = _Repair.RepairHEKCommisionMembers.AddNew();
                repairHEKCommisionMember.CommisionOrderNo = 4;
                repairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.Chief;

                repairHEKCommisionMember = _Repair.RepairHEKCommisionMembers.AddNew();
                repairHEKCommisionMember.CommisionOrderNo = 5;
                repairHEKCommisionMember.MemberDuty = CommisionMemberDutyEnum.Approval;

            }
            
            string description ="";
            string hekNedeni = "";
            string aciklama= "    Yukarıda marka modeli belirtilen cihaz, uzun süreli kullanımdan dolayı kullanıcı hatası olmaksızın normal aşınma ve yıpranma sonucu nitelik ve özelliklerini kaybetmiştir.\n Cihazın yapılan incelemesinde; ";
            string aciklama2= " tespit edilmiştir. Cihazın mevcut durumu nedeniyle onarılmasının mümkün olmayacağı değerlendirilmiştir.\n   Cihazın eski model ve eski teknoloji ürünü olması nedeniyle yenileştirilmesi mümkün değildir.";
            string aciklama3="\n    Yukarıda belirtilen nedenlerden dolayı; MSY 59-2(A) XXXXXX Taşınır Mal Yönergesinin 5.ncü bölüm 1.inci maddesi I-";
            string aciklama4= "  dolayı kayıt silme işlemine tabi tutulmasının uygun olacağı değerlendirilmiştir.";
            if(_Repair.HEKReportRepairDetail == null && _Repair.HEKReportDescription != null && _Repair.RepairNotes != null)
            {
                foreach (RULHEKReason rulHek in _Repair.RULHEKReasons)
                {
                    if (rulHek.Check == true)
                    {
                        hekNedeni = rulHek.CousesOfTheHekDefinition.Counter + " fıkrasında belirtildiği üzere " + rulHek.CousesOfTheHekDefinition.Description;
                        description= aciklama + TTObjectClasses.Common.GetTextOfRTFString(_Repair.HEKReportDescription) + aciklama2 + aciklama3  + hekNedeni + aciklama4;
                        _Repair.HEKReportRepairDetail = TTObjectClasses.Common.GetRTFOfTextString(description);
                        break;
                        
                        
                    }
                }
            }
#endregion HEKForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HEKForm_PostScript
    base.PostScript(transDef);

            if (HEKCommisionGrid.Rows.Count == 0)
            {
                string message = SystemMessage.GetMessage(51);
                throw new TTUtils.TTException(message);
            }
            if (TTRichTextBoxUserControl.Text == "")
            {
                string message = SystemMessage.GetMessage(52);
                throw new TTUtils.TTException(message);
            }
#endregion HEKForm_PostScript

            }
                }
}