
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
    /// Uzmanlık Dalı
    /// </summary>
    public partial class SpecialityDefinition : BaseMedulaDefinition
    {
        public partial class OLAP_SpecialityDefinition_Class : TTReportNqlObject
        {
        }

        public partial class GetSpecialityDefinitionNql_Class : TTReportNqlObject
        {
        }

        public partial class GetSpecialityDefinitionQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetAllSpecialityDefinition_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();

            if (IsMinorSpeciality.Value == true && MHRSClinicCode == null)
                throw new Exception(TTUtils.CultureService.GetText("M27205", "Yandal uzmanlığı seçtiyseniz MHRS Klinik Kodunu da girmelisiniz !"));

            Common.SohaRuleRuleRepositoryChanged(ObjectContext, SohaRuleRepoTypeEnum.BranchRepository);
            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();

            if (IsMinorSpeciality != null && IsMinorSpeciality.Value == true && MHRSClinicCode == null)
                throw new Exception(TTUtils.CultureService.GetText("M27205", "Yandal uzmanlığı seçtiyseniz MHRS Klinik Kodunu da girmelisiniz !"));

            if(this.HasMemberChanged("CODE") || this.HasMemberChanged("NAME"))
                Common.SohaRuleRuleRepositoryChanged(ObjectContext, SohaRuleRepoTypeEnum.BranchRepository);
            #endregion PreUpdate
        }

        #region Methods
        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.SpecialityDefinitionInfo;
        }


        public static SpecialityDefinition GetBrans(string code)
        {
            SpecialityDefinition retValue = null;
            if (string.IsNullOrEmpty(code) == false)
                _allBrans.TryGetValue(code, out retValue);
            return retValue;
        }

        private static Dictionary<string, SpecialityDefinition> _allBrans;

        static SpecialityDefinition()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allBrans = new Dictionary<string, SpecialityDefinition>();
            foreach (SpecialityDefinition brans in context.QueryObjects<SpecialityDefinition>())
            {
                if (_allBrans.ContainsKey(brans.Code) == false && brans.Code != null)
                    _allBrans.Add(brans.Code, brans);
            }
        }

        public override string ToString()
        {
            return Code + " : " + Name;
        }

        public static SpecialityDefinition GetSpecialityByResUser(ResUser resUser)
        {
            if (resUser.ResourceSpecialities.Count > 0)
            {
                if (resUser.ResourceSpecialities.Count > 1)
                {
                    foreach (ResourceSpecialityGrid sp in resUser.ResourceSpecialities)
                    {
                        if (sp.MainSpeciality != null)
                        {
                            if (sp.MainSpeciality.Value == true && sp.Speciality != null)
                                return sp.Speciality;
                        }
                    }
                }

                if (resUser.ResourceSpecialities[0].Speciality != null)
                    return resUser.ResourceSpecialities[0].Speciality;
            }

            return null;
        }

        public BulletinProcedureDefinition BulletinProcedure
        {
            get
            {
                if (IsBulletin == true)
                {
                    if (string.IsNullOrEmpty(Code) || Code.Trim() == string.Empty)
                        throw new TTUtils.TTException("'" + Name + "' isimli branşın kodu bilinmediği için Vakabaşı Hizmeti'ne ulaşılamıyor.");

                    BindingList<BulletinProcedureDefinition> bulletinProcedures = BulletinProcedureDefinition.GetByCode(ObjectContext, Code.Trim(), " AND ISACTIVE = 1");

                    if (bulletinProcedures.Count == 0)
                        throw new TTUtils.TTException("'" + Code + "' kodlu aktif bir Vakabaşı Hizmeti bulunamadı.");

                    if (bulletinProcedures.Count > 1)
                        throw new TTUtils.TTException("'" + Code + "' kodlu aktif birden çok Vakabaşı Hizmeti bulundu.");

                    return bulletinProcedures[0];
                }

                return null;
            }
        }

        #endregion Methods

    }
}