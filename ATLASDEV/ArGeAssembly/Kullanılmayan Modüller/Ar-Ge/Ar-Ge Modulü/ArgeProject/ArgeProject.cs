
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
    /// Proje Başvuru Formu
    /// </summary>
    public  partial class ArgeProject : BaseAction, IWorkListBaseAction
    {
        public string ProjectConcumableMaterialCosts
        {
            get
            {
                try
                {
#region ProjectConcumableMaterialCosts_GetScript                    
                    return CalcConsumableCosts();
#endregion ProjectConcumableMaterialCosts_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ProjectConcumableMaterialCosts") + " : " + ex.Message, ex);
                }
            }
        }

        public string ProjectDutyCosts
        {
            get
            {
                try
                {
#region ProjectDutyCosts_GetScript                    
                    return CalcDutyCosts();
#endregion ProjectDutyCosts_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ProjectDutyCosts") + " : " + ex.Message, ex);
                }
            }
        }

        public string ProjectReagentCosts
        {
            get
            {
                try
                {
#region ProjectReagentCosts_GetScript                    
                    return CalcReagentCosts();
#endregion ProjectReagentCosts_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ProjectReagentCosts") + " : " + ex.Message, ex);
                }
            }
        }

        public string ProjectTotalCosts
        {
            get
            {
                try
                {
#region ProjectTotalCosts_GetScript                    
                    return CalcTotalCosts();
#endregion ProjectTotalCosts_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ProjectTotalCosts") + " : " + ex.Message, ex);
                }
            }
        }

        public string ProjectOtherCosts
        {
            get
            {
                try
                {
#region ProjectOtherCosts_GetScript                    
                    return CalcOtherCosts();
#endregion ProjectOtherCosts_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ProjectOtherCosts") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();

#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();
            WorkListDescription = ProjectOwner.Name + " adlı proje sahibine ait " + StartDate + " tarihinde başlammış " + ProjectName + " projesidir.";
#endregion PostUpdate
        }

        protected void PreTransition_New2PreClaimApealApprove()
        {
            // From State : New   To State : PreClaimApealApprove
#region PreTransition_New2PreClaimApealApprove
            
            
            //this.ProjectStatus = ProjectStatusTypes.InCreation;
            //this.ProjectStatus = ProjectStatusTypes.InCreation.ToString();
#endregion PreTransition_New2PreClaimApealApprove
        }

        protected void PostTransition_AcademicCommApproval2AdvisorApproval()
        {
            // From State : AcademicCommApproval   To State : AdvisorApproval
#region PostTransition_AcademicCommApproval2AdvisorApproval
            
            if (ProjectRaportor == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M26709", "Projeye Raportör Atamalısınız."));
            }
            if (_Advisiors.Count ==0)
            {
                throw new TTException(TTUtils.CultureService.GetText("M26708", "Projeye ait en az 1 en fazla 2 proje danışmanı olmalıdır."));
            }
#endregion PostTransition_AcademicCommApproval2AdvisorApproval
        }

        protected void PostTransition_PreClaimApealApprove2New()
        {
            // From State : PreClaimApealApprove   To State : New
#region PostTransition_PreClaimApealApprove2New
            PreAssesment.PreAssesmentDate = DateTime.Now;

#endregion PostTransition_PreClaimApealApprove2New
        }

        protected void PostTransition_PreClaimApealApprove2AcademicCommApproval()
        {
            // From State : PreClaimApealApprove   To State : AcademicCommApproval
#region PostTransition_PreClaimApealApprove2AcademicCommApproval
            
            
            if (string.IsNullOrEmpty(PreAssesment.PreAssementResult))
            {
                throw new TTException(TTUtils.CultureService.GetText("M26666", "Ön Değerlendirme Sonucu Girmelisiniz."));
            }
            
            PreAssesment.PreAssesmentDate=DateTime.Now;
#endregion PostTransition_PreClaimApealApprove2AcademicCommApproval
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
                ProjectNo.GetNextValue();
        }

        private Hashtable getConsumableCosts()
        {
            int x = ConsumableMaterials.Count;
            Hashtable htExchange = new Hashtable();
            Currency price = 0;
            if (_ConsumableMaterials != null && _ConsumableMaterials.Count > 0)
            {
                foreach (ConsumableMaterialDetail cmd in _ConsumableMaterials)
                {
                    if (cmd.StockOut != null)
                    {
                        if (!htExchange.Contains(cmd.ExchangeType.Name.ToString()))
                            htExchange.Add(cmd.ExchangeType.Name.ToString(), (cmd.StockOut.TotalPrice * cmd.Amount));
                        else
                        {
                            price = (Currency)(htExchange[cmd.ExchangeType.Name.ToString()]);
                            price += (Currency)(cmd.StockOut.TotalPrice * cmd.Amount);
                            htExchange[cmd.ExchangeType.Name.ToString()] = price;
                        }
                    }
                }
            }
            return htExchange;
        }
        public string CalcConsumableCosts()
        {
            string retValue = string.Empty;
            Hashtable htExchange = getConsumableCosts();
            if (htExchange.Count > 0)
            {
                string totPrice = string.Empty;
                string exchange = string.Empty;
                IDictionaryEnumerator dick = htExchange.GetEnumerator();
                while (dick.MoveNext()) 
                {
                    exchange = dick.Key.ToString();
                    totPrice = dick.Value.ToString();
                    retValue += totPrice + " " + exchange + " ";
                }

            }
            return retValue;
        }
        private Hashtable getDutyCosts()
        {
            int x = DutyCosts.Count;
            Hashtable htExchange = new Hashtable();
            Currency price = 0;
            if (_DutyCosts != null && _DutyCosts.Count > 0)
            {
                foreach (DutiesDetail dd in _DutyCosts)
                {
                    if (!htExchange.Contains(dd.ExchangeType.Name.ToString()))
                        htExchange.Add(dd.ExchangeType.Name.ToString(), dd.DutyCostPrice);
                    else
                    {
                        price = (Currency)(htExchange[dd.ExchangeType.Name.ToString()]);
                        price += (Currency)dd.DutyCostPrice;
                        htExchange[dd.ExchangeType.Name.ToString()] = price;
                    }
                }
            }
            return htExchange;
        }
        public string CalcDutyCosts()
        {
            string retValue = string.Empty;
            Hashtable htExchange = getDutyCosts();
            if (htExchange.Count > 0)
            {
                string totPrice = string.Empty;
                string exchange = string.Empty;
                IDictionaryEnumerator dick = htExchange.GetEnumerator();
                while (dick.MoveNext())
                {
                    exchange = dick.Key.ToString();
                    totPrice = dick.Value.ToString();
                    retValue += totPrice + " " + exchange + " ";
                }
            }
            return retValue;
        }
        private Hashtable getOtherCosts()
        {
            int x = OtherCosts.Count;
            Hashtable htExchange = new Hashtable();
            Currency price = 0;
            if (_OtherCosts != null && _OtherCosts.Count > 0)
            {
                foreach (OtherCostDetail ocd in _OtherCosts)
                {
                    if (!htExchange.Contains(ocd.ExchangeType.Name.ToString()))
                        htExchange.Add(ocd.ExchangeType.Name.ToString(), ocd.OtherCostPrice);
                    else
                    {
                        price = (Currency)(htExchange[ocd.ExchangeType.Name.ToString()]);
                        price += (Currency)ocd.OtherCostPrice;
                        htExchange[ocd.ExchangeType.Name.ToString()] = price;
                    }
                }
            }
            return htExchange;
        }
        public string CalcOtherCosts()
        {
            string retValue = string.Empty;
            Hashtable htExchange = getOtherCosts();
            if (htExchange.Count > 0)
            {
                string totPrice = string.Empty;
                string exchange = string.Empty;
                IDictionaryEnumerator dick = htExchange.GetEnumerator();
                while (dick.MoveNext())
                {
                    exchange = dick.Key.ToString();
                    totPrice = dick.Value.ToString();
                    retValue += totPrice + " " + exchange + " ";
                }
            }
            return retValue;
        }

        private Hashtable getReagentCosts()
        {
            int x = ReagentCosts.Count;
            Hashtable htExchange = new Hashtable();
            Currency price = 0;
            if (_ReagentCosts != null && _ReagentCosts.Count > 0)
            {
                foreach (ReagentDetail rd in _ReagentCosts)
                {
                    if (!htExchange.Contains(rd.ExchangeType.Name.ToString()))
                        htExchange.Add(rd.ExchangeType.Name.ToString(), (rd.ReagentPrice * rd.ReagentAmmount));
                    else
                    {
                        price = (Currency)(htExchange[rd.ExchangeType.Name.ToString()]);
                        price += (Currency)(rd.ReagentPrice * rd.ReagentAmmount);
                        htExchange[rd.ExchangeType.Name.ToString()] = price;
                    }
                }
            }
            return htExchange;
        }

        public string CalcReagentCosts()
        {
            string retValue = string.Empty;
            Hashtable htExchange = getReagentCosts();
            if (htExchange.Count > 0)
            {
                string totPrice = string.Empty;
                string exchange = string.Empty;
                IDictionaryEnumerator dick = htExchange.GetEnumerator();
                while (dick.MoveNext())
                {
                    exchange = dick.Key.ToString();
                    totPrice = dick.Value.ToString();
                    retValue += totPrice + " " + exchange + " ";
                }

            }
            return retValue;
        }
        public string CalcTotalCosts()
        {
            string retValue = string.Empty;
            Hashtable htTotalExchange = new Hashtable();
            Currency price;
            IDictionaryEnumerator dickReagent = getReagentCosts().GetEnumerator();
            while (dickReagent.MoveNext())
                htTotalExchange.Add(dickReagent.Key, dickReagent.Value);

            IDictionaryEnumerator dickOther = getOtherCosts().GetEnumerator();
            while (dickOther.MoveNext())
            {
                if (!htTotalExchange.Contains(dickOther.Key))
                    htTotalExchange.Add(dickOther.Key, dickOther.Value);
                else
                {
                    price = (Currency)htTotalExchange[dickOther.Key] + (Currency)dickOther.Value;
                    htTotalExchange[dickOther.Key] = price.ToString();
                }
            }

            IDictionaryEnumerator dickDuty = getDutyCosts().GetEnumerator();
            while (dickDuty.MoveNext())
            {
                if (!htTotalExchange.Contains(dickDuty.Key))
                    htTotalExchange.Add(dickDuty.Key, dickDuty.Value);
                else
                {
                    price = (Currency)htTotalExchange[dickDuty.Key] + (Currency)dickDuty.Value;
                    htTotalExchange[dickDuty.Key] = price.ToString();
                }
            }

            IDictionaryEnumerator dickConsumable = getConsumableCosts().GetEnumerator();
            while (dickConsumable.MoveNext())
            {
                if (!htTotalExchange.Contains(dickConsumable.Key))
                    htTotalExchange.Add(dickConsumable.Key, dickConsumable.Value);
                else
                {
                    price = (Currency)htTotalExchange[dickConsumable.Key] + (Currency)dickConsumable.Value;
                    htTotalExchange[dickConsumable.Key] = price.ToString();
                }
            }
            if (htTotalExchange.Count > 0)
            {
                string totPrice = string.Empty;
                string exchange = string.Empty;
                IDictionaryEnumerator dick = htTotalExchange.GetEnumerator();
                while (dick.MoveNext())
                {
                    exchange = dick.Key.ToString();
                    totPrice = dick.Value.ToString();
                    retValue += totPrice + " " + exchange + " ";
                }

            }
            return retValue;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ArgeProject).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.New && toState == States.PreClaimApealApprove)
                PreTransition_New2PreClaimApealApprove();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ArgeProject).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.AcademicCommApproval && toState == States.AdvisorApproval)
                PostTransition_AcademicCommApproval2AdvisorApproval();
            else if (fromState == States.PreClaimApealApprove && toState == States.New)
                PostTransition_PreClaimApealApprove2New();
            else if (fromState == States.PreClaimApealApprove && toState == States.AcademicCommApproval)
                PostTransition_PreClaimApealApprove2AcademicCommApproval();
        }

    }
}