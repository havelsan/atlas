
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


using TTUtils.RequirementManager;
using static TTConnectionManager.ConnectionManager;
namespace TTObjectClasses
{
    /// <summary>
    /// Kullanıcı
    /// </summary>
    public partial class ResUser : Resource, ITTUserObject
    {
        public partial class OLAP_GetResDoctor_Class : TTReportNqlObject
        {
        }

        public partial class ClinicDoctorListNQL_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetDoctorCount_Class : TTReportNqlObject
        {
        }

        public partial class GetUserByID_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetNurseCount_Class : TTReportNqlObject
        {
        }

        public partial class GetUserInfoNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetResUser_Class : TTReportNqlObject
        {
        }

        public partial class DoctorListNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetAllUserReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetConsultationUserNQL_Class : TTReportNqlObject
        {
        }

        public partial class VEM_PERSONEL_Class : TTReportNqlObject
        {
        }

        public partial class GetdoctorsForMHRS_Class : TTReportNqlObject
        {
        }

        public partial class SpecialistDoctorListNQL_Class : TTReportNqlObject
        {
        }
        public string ClientComputerName { get; set; }
        public string SignatureBlockWDiplomaInfo
        {
            get
            {
                try
                {
                    #region SignatureBlockWDiplomaInfo_GetScript                    
                    string signatureBlockWDiplomaInfo = "";

                    signatureBlockWDiplomaInfo += Name + "\n\r";

                    if (TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "") != "TRUE" && TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "") != "True")
                    {
                        if (MilitaryClass != null)
                            signatureBlockWDiplomaInfo += MilitaryClass.Name;
                    }
                    else
                    {
                        if (Title != null && Title != UserTitleEnum.Unused)
                            signatureBlockWDiplomaInfo += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(Title.Value).DisplayText;
                        else
                        {
                            if (MilitaryClass != null)
                                signatureBlockWDiplomaInfo += MilitaryClass.Name;
                        }
                    }

                    if (Rank != null)
                        signatureBlockWDiplomaInfo += " " + Rank.Name;

                    if (UserType != null)
                    {
                        if (UserType.Value == UserTypeEnum.Psychologist)
                            signatureBlockWDiplomaInfo += " Psikolog";
                    }

                    signatureBlockWDiplomaInfo += "\n\r";

                    /*
                    if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
                    {
                        signatureBlockWDiplomaInfo += "SİCİL NO :";
                        if(this.EmploymentRecordID!=null)
                            signatureBlockWDiplomaInfo += this.EmploymentRecordID.ToString();
                    }
                    else
                    {
                        signatureBlockWDiplomaInfo += "DİPLOMA NO :";
                            if(this.DiplomaNo!=null)
                            signatureBlockWDiplomaInfo +=this.DiplomaNo.ToString();
                        
                            signatureBlockWDiplomaInfo +="DİPLOMA TESCİL NO :";
                            if(this.DiplomaRegisterNo != null)
                                signatureBlockWDiplomaInfo +=this.DiplomaRegisterNo.ToString();
                    }
                
                     */

                    signatureBlockWDiplomaInfo += "SİCİL NO :";
                    if (EmploymentRecordID != null)
                        signatureBlockWDiplomaInfo += EmploymentRecordID.ToString();
                    signatureBlockWDiplomaInfo += "\n\r";
                    signatureBlockWDiplomaInfo += "DİPLOMA NO :";
                    if (DiplomaNo != null)
                        signatureBlockWDiplomaInfo += DiplomaNo.ToString();

                    signatureBlockWDiplomaInfo += " DİPLOMA TESCİL NO :";
                    if (DiplomaRegisterNo != null)
                        signatureBlockWDiplomaInfo += DiplomaRegisterNo.ToString();


                    signatureBlockWDiplomaInfo += "\n\r";

                    if (ResourceSpecialities.Count == 0)
                    {
                        if (UserType != null)
                        {
                            if (UserType.Value == UserTypeEnum.Dentist ||
                                UserType.Value == UserTypeEnum.Operator ||
                                UserType.Value == UserTypeEnum.Doctor ||
                                UserType.Value == UserTypeEnum.InternDoctor
                               )
                            {
                                signatureBlockWDiplomaInfo += TTUtils.CultureService.GetText("M26703", "Pratisyen");
                            }
                        }
                    }
                    else if (ResourceSpecialities.Count == 1)
                    {
                        if (ResourceSpecialities[0].Speciality != null)
                            signatureBlockWDiplomaInfo += ResourceSpecialities[0].Speciality.Name;
                    }
                    else
                    {
                        foreach (ResourceSpecialityGrid sp in ResourceSpecialities)
                        {

                            if (sp.Speciality != null)
                            {
                                signatureBlockWDiplomaInfo += sp.Speciality.Name;
                                signatureBlockWDiplomaInfo += "\n\r";
                            }

                        }
                    }

                    return (string)signatureBlockWDiplomaInfo;
                    #endregion SignatureBlockWDiplomaInfo_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "SignatureBlockWDiplomaInfo") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
                    #region SignatureBlockWDiplomaInfo_SetScript                    
                    this[ColumnNames.SignatureBlockWDiplomaInfo] = value;
                    #endregion SignatureBlockWDiplomaInfo_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "SignatureBlockWDiplomaInfo") + " : " + ex.Message, ex);
                }
            }
        }

        public string SignatureBlockForPrescriptionReport
        {
            get
            {
                try
                {
                    #region SignatureBlockForPrescriptionReport_GetScript                    
                    string signatureBlockForPrescriptionReport = "";

                    signatureBlockForPrescriptionReport += Name + "\n\r";

                    if (TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "") != "TRUE" && TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "") != "True")
                    {
                        if (MilitaryClass != null)
                            signatureBlockForPrescriptionReport += MilitaryClass.Name;
                    }
                    else
                    {
                        if (Title != null && Title != UserTitleEnum.Unused)
                            signatureBlockForPrescriptionReport += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(Title.Value).DisplayText;
                        else
                        {
                            if (MilitaryClass != null)
                                signatureBlockForPrescriptionReport += MilitaryClass.Name;
                        }
                    }

                    if (Rank != null)
                        signatureBlockForPrescriptionReport += " " + Rank.Name;

                    if (UserType != null)
                    {
                        if (UserType.Value == UserTypeEnum.Psychologist)
                            signatureBlockForPrescriptionReport += " Psikolog";
                    }

                    signatureBlockForPrescriptionReport += "\n\r";

                    /*
                    if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
                    {
                        signatureBlockForPrescriptionReport += "SİCİL NO :";
                        if(this.EmploymentRecordID!=null)
                            signatureBlockForPrescriptionReport += this.EmploymentRecordID.ToString();
                    }
                    else
                    {
                        signatureBlockForPrescriptionReport += "DİPLOMA NO :";
                            if(this.DiplomaNo!=null)
                            signatureBlockForPrescriptionReport +=this.DiplomaNo.ToString();
                        
                            signatureBlockForPrescriptionReport +="DİPLOMA TESCİL NO :";
                            if(this.DiplomaRegisterNo != null)
                                signatureBlockForPrescriptionReport +=this.DiplomaRegisterNo.ToString();
                    }
                
                     */

                    //signatureBlockForPrescriptionReport += "SİCİL NO :";
                    if (EmploymentRecordID != null)
                        signatureBlockForPrescriptionReport += EmploymentRecordID.ToString();
                    signatureBlockForPrescriptionReport += "\n\r";
                    signatureBlockForPrescriptionReport += "DİPLOMA NO :";
                    if (DiplomaNo != null)
                        signatureBlockForPrescriptionReport += DiplomaNo.ToString();

                    signatureBlockForPrescriptionReport += " DİPLOMA TESCİL NO :";
                    if (DiplomaRegisterNo != null)
                        signatureBlockForPrescriptionReport += DiplomaRegisterNo.ToString();


                    signatureBlockForPrescriptionReport += "\n\r";

                    if (ResourceSpecialities.Count == 0)
                    {
                        if (UserType != null)
                        {
                            if (UserType.Value == UserTypeEnum.Dentist ||
                                UserType.Value == UserTypeEnum.Operator ||
                                UserType.Value == UserTypeEnum.Doctor ||
                                UserType.Value == UserTypeEnum.InternDoctor
                               )
                            {
                                signatureBlockForPrescriptionReport += TTUtils.CultureService.GetText("M26703", "Pratisyen");
                            }
                        }
                    }
                    else if (ResourceSpecialities.Count == 1)
                    {
                        if (ResourceSpecialities[0].Speciality != null)
                            signatureBlockForPrescriptionReport += ResourceSpecialities[0].Speciality.Name;
                    }
                    else
                    {
                        foreach (ResourceSpecialityGrid sp in ResourceSpecialities)
                        {

                            if (sp.Speciality != null)
                            {
                                signatureBlockForPrescriptionReport += sp.Speciality.Name;
                                signatureBlockForPrescriptionReport += "\n\r";
                            }

                        }
                    }

                    //return (string)signatureBlockWDiplomaInfo;
                    //return (string)this["SignatureBlockForPrescriptionReport"];
                    return (string)signatureBlockForPrescriptionReport;
                    #endregion SignatureBlockForPrescriptionReport_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "SignatureBlockForPrescriptionReport") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
                    #region SignatureBlockForPrescriptionReport_SetScript                    
                    this[ColumnNames.SignatureBlockForPrescriptionReport] = value;
                    #endregion SignatureBlockForPrescriptionReport_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "SignatureBlockForPrescriptionReport") + " : " + ex.Message, ex);
                }
            }
        }

        public string SignatureBlock
        {
            get
            {
                try
                {
                    #region SignatureBlock_GetScript                    
                    string signatureBlock = "";

                    signatureBlock += Name + "\n\r";

                    if (TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "") != "TRUE" && TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "") != "True")
                    {
                        if (MilitaryClass != null)
                            signatureBlock += MilitaryClass.Name;
                    }
                    else
                    {
                        if (Title != null && Title != UserTitleEnum.Unused)
                            signatureBlock += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(Title.Value).DisplayText;
                        else
                        {
                            if (MilitaryClass != null)
                                signatureBlock += MilitaryClass.Name;
                        }
                    }

                    if (Rank != null)
                        signatureBlock += " " + Rank.Name;

                    if (UserType != null)
                    {
                        if (UserType.Value == UserTypeEnum.Psychologist)
                            signatureBlock += " Psikolog";
                    }

                    signatureBlock += "\n\r";

                    if (TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "") == "TRUE")
                    {
                        signatureBlock += "SİCİL NO :";
                        if (EmploymentRecordID != null)
                            signatureBlock += EmploymentRecordID.ToString();
                    }
                    else
                    {
                        signatureBlock += "DİPLOMA NO :";
                        if (DiplomaNo != null)
                            signatureBlock += DiplomaNo.ToString();

                        signatureBlock += "DİPLOMA TESCİL NO :";
                        if (DiplomaRegisterNo != null)
                            signatureBlock += DiplomaRegisterNo.ToString();
                    }

                    signatureBlock += "\n\r";

                    if (ResourceSpecialities.Count == 0)
                    {
                        if (UserType != null)
                        {
                            if (UserType.Value == UserTypeEnum.Dentist ||
                                UserType.Value == UserTypeEnum.Operator ||
                                UserType.Value == UserTypeEnum.Doctor ||
                                UserType.Value == UserTypeEnum.InternDoctor
                               )
                            {
                                signatureBlock += TTUtils.CultureService.GetText("M26703", "Pratisyen");
                            }
                        }
                    }
                    else if (ResourceSpecialities.Count == 1)
                    {
                        if (ResourceSpecialities[0].Speciality != null)
                            signatureBlock += ResourceSpecialities[0].Speciality.Name;
                    }
                    else
                    {
                        foreach (ResourceSpecialityGrid sp in ResourceSpecialities)
                        {
                            if (sp.Speciality != null)
                            {
                                signatureBlock += sp.Speciality.Name;
                                signatureBlock += "\n\r";
                            }
                        }
                    }

                    return (string)signatureBlock;
                    #endregion SignatureBlock_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "SignatureBlock") + " : " + ex.Message, ex);
                }
            }
        }

        public string ShortSignatureBlock
        {
            get
            {
                try
                {
                    #region ShortSignatureBlock_GetScript                    
                    string signatureBlock = "";

                    signatureBlock += Name + "\n\r";

                    //if (TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "") != "TRUE" && TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "") != "True")
                    //{
                    //    if (this.MilitaryClass != null)
                    //        signatureBlock += this.MilitaryClass.Name;
                    //}
                    //else
                    //{
                    //if (this.Title != null && this.Title != UserTitleEnum.Unused)
                    //    signatureBlock += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(this.Title.Value).DisplayText;
                    //else
                    //{
                    //    if (this.MilitaryClass != null)
                    //        signatureBlock += this.MilitaryClass.Name;
                    //}
                    //}

                    //if (this.Rank != null)
                    //    signatureBlock += " " + this.Rank.Name;

                    if (UserType != null)
                    {
                        if (UserType.Value == UserTypeEnum.Psychologist)
                        {
                            signatureBlock += " Psikolog";
                            signatureBlock += "\n\r";
                        }
                    }

                    ////signatureBlock += "\n\r";

                    //if (TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "") == "TRUE")
                    //{
                    //    signatureBlock += "SİCİL NO :";
                    //    if (this.EmploymentRecordID != null)
                    //        signatureBlock += this.EmploymentRecordID.ToString();
                    //}
                    //else
                    //{
                    //    signatureBlock += "DİPLOMA NO :";
                    //    if (this.DiplomaNo != null)
                    //        signatureBlock += this.DiplomaNo.ToString();

                    //    signatureBlock += "DİPLOMA TESCİL NO :";
                    //    if (this.DiplomaRegisterNo != null)
                    //        signatureBlock += this.DiplomaRegisterNo.ToString();
                    //}

                    ////signatureBlock += "\n\r";

                    if (ResourceSpecialities.Count == 0)
                    {
                        if (UserType != null)
                        {
                            if (UserType.Value == UserTypeEnum.Dentist ||
                                UserType.Value == UserTypeEnum.Operator ||
                                UserType.Value == UserTypeEnum.Doctor ||
                                UserType.Value == UserTypeEnum.InternDoctor
                               )
                            {
                                signatureBlock += " Pratisyen";
                            }
                        }
                    }
                    else if (ResourceSpecialities.Count == 1)
                    {
                        if (ResourceSpecialities[0].Speciality != null)
                            signatureBlock += ResourceSpecialities[0].Speciality.Name;
                    }
                    else
                    {
                        foreach (ResourceSpecialityGrid sp in ResourceSpecialities)
                        {
                            if (sp.Speciality != null)
                            {
                                signatureBlock += sp.Speciality.Name;
                                signatureBlock += "\n\r";
                            }
                        }
                    }

                    return (string)signatureBlock;
                    #endregion ShortSignatureBlock_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ShortSignatureBlock") + " : " + ex.Message, ex);
                }
            }
        }

        public string UniqueNo
        {
            get
            {
                try
                {
                    #region UniqueNo_GetScript                    
                    string refNo = string.Empty;
                    if (Person != null && Person.UniqueRefNo != null)
                        refNo = Person.UniqueRefNo.ToString();

                    return refNo;
                    #endregion UniqueNo_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "UniqueNo") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            ControlDiplomaNo();
            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            ControlDiplomaNo();
            #endregion PreUpdate
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            SetTakesPerformanceScore();
            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            SetTakesPerformanceScore();
            #endregion PostUpdate
        }

        protected override void PreDelete()
        {
            #region PreDelete









            base.PreDelete();
            string department = "";
            foreach (UserResource userResource in UserResources)
            {
                if (userResource.Resource != null)
                {
                    department += "\r\n" + userResource.Resource.Name;
                }
            }
            if (department != "")
            {
                throw new Exception(SystemMessage.GetMessageV3(543, new string[] { Name.ToString(), department }));
            }

            if (Person != null)
                ((ITTObject)Person).Delete();



            #endregion PreDelete
        }

        #region Methods

        public void ControlDiplomaNo()
        {
            if ((UserType == UserTypeEnum.Doctor || UserType == UserTypeEnum.Dentist || UserType == UserTypeEnum.InternDoctor) && string.IsNullOrEmpty(DiplomaNo))
            {
                throw new Exception("Mesleği 'Doktor', 'Diş Tabibi' ve 'Intern Doktor' seçilen kullanıcılar için 'Diploma No' alanı zorunludur.");
            }
        }

        public void SetTakesPerformanceScore()
        {
            TakesPerformanceScore = false;
            if (UserType != null && Title != null)
            {
                if (UserType == UserTypeEnum.Doctor || UserType == UserTypeEnum.Dentist)
                {
                    if (Title != UserTitleEnum.UzmanOgr &&
                       Title != UserTitleEnum.DoktoraOgr &&
                       Title != UserTitleEnum.YanDalUzmanOgr &&
                       Title != UserTitleEnum.YLisansUzmanOgr &&
                       Title != UserTitleEnum.Unused &&
                       Title != UserTitleEnum.UzmanEcz)
                    {
                        TakesPerformanceScore = true;
                    }
                }
            }
        }

        public static List<UserOptionType> GetUserOptionTypes(UserOptionGroupType userOptionGroupType)
        {
            List<UserOptionType> retval = new List<UserOptionType>();
            TTObjectContext objectContext = new TTObjectContext(true);
            foreach (UserOptionGroup uotg in UserOptionGroup.GetUserOptionGroups(objectContext, userOptionGroupType))
            {
                retval.Add(uotg.UserOptionType.Value);
            }
            return retval;
        }

        /// <summary>
        /// Parametre kaydetmek için
        /// </summary>
        /// <param name="OptionType"></param>
        /// <returns></returns>
        public void SaveUserOption(UserOptionType optionType, string value)
        {
            UserOption uo = GetUserOption(optionType);

            Boolean create = false;
            if (uo == null)
                create = true;
            else if (uo.ResUser == null)
                create = true;

            if (create == true)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                uo = new UserOption(objectContext);
                uo.OptionType = optionType;
                uo.Value = value;
                UserOptions.Add(uo);
                objectContext.Save();
            }
            else
            {
                uo.Value = value;
                uo.ObjectContext.Save();
            }
        }


        /// <summary>
        /// Parametre kaydetmek için
        /// </summary>
        /// <param name="OptionType"></param>
        /// <returns></returns>
        public void SaveUserOption(UserOptionType optionType, string value, string description, QuestionTypeEnum questionType)
        {
            UserOption uo = GetUserOption(optionType);

            Boolean create = false;
            if (uo == null)
                create = true;
            else if (uo.ResUser == null)
                create = true;

            if (create == true)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                uo = new UserOption(objectContext);
                uo.OptionType = optionType;
                uo.Value = value;
                uo.Description = description;
                uo.QuestionType = questionType;
                UserOptions.Add(uo);
                objectContext.Save();
            }
            else
            {
                uo.Value = value;
                uo.ObjectContext.Save();
            }
        }




        /// <summary>
        /// Parametre kaydetmek için
        /// </summary>
        /// <param name="OptionType"></param>
        /// <returns></returns>
        public void SaveUserOptionValue(UserOptionType optionType, object optionValue)
        {
            UserOption uo = GetUserOption(optionType);

            Boolean create = false;
            if (uo == null)
                create = true;
            else if (uo.ResUser == null)
                create = true;

            if (create == true)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                uo = new UserOption(objectContext);
                uo.OptionType = optionType;
                uo.OptionValue = optionValue;
                UserOptions.Add(uo);
                objectContext.Save();
            }
            else
            {
                uo.OptionValue = optionValue;
                uo.ObjectContext.Save();
            }
        }

        /// <summary>
        /// Kullanıcı parametresi almak için
        /// </summary>
        /// <param name="OptionType"></param>
        /// <returns></returns>
        public UserOption GetUserOption(UserOptionType optionType)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            foreach (UserOption uo in UserOption.GetOption(objectContext, ObjectID.ToString(), optionType))
            {
                return uo;
            }
            foreach (UserOption uo in UserOption.GetSystemOption(objectContext, optionType))
            {
                return uo;
            }
            return null;
        }

        /// <summary>
        /// Kullanıcıya ait bütün UserOption ları getitir.
        /// </summary>
        public BindingList<UserOption> GetCurrentUsersAllOtions()
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            return UserOption.GetCurrentUserSAllOptions(objectContext, ObjectID.ToString());
        }

        public List<Resource> InPatientUserResources;
        public List<Resource> OutPatientUserResources;
        public List<Resource> SecMasterUserResources;
        public List<ExaminationQueueDefinition> UserQueues;

        public void FillUserResources()
        {
            TTObjectContext context = new TTObjectContext(true);
            InPatientUserResources = new List<Resource>();
            OutPatientUserResources = new List<Resource>();
            SecMasterUserResources = new List<Resource>();
            UserQueues = new List<ExaminationQueueDefinition>();
            foreach (UserResource userResource in UserResources)
            {
                if (userResource.Resource != null && userResource.Resource.IsActive == true)
                {
                    switch (userResource.Resource.EnabledType)
                    {
                        case ResourceEnableType.BothInpatientAndOutPatient:
                            if(!InPatientUserResources.Contains(userResource.Resource))
                                InPatientUserResources.Add(userResource.Resource);
                            if (!OutPatientUserResources.Contains(userResource.Resource))
                                OutPatientUserResources.Add(userResource.Resource);
                            break;
                        case ResourceEnableType.InPatient:
                            if (!InPatientUserResources.Contains(userResource.Resource))
                                InPatientUserResources.Add(userResource.Resource);
                            break;
                        case ResourceEnableType.OutPatient:
                            if (!OutPatientUserResources.Contains(userResource.Resource))
                                OutPatientUserResources.Add(userResource.Resource);
                            break;
                        case ResourceEnableType.Secmaster:
                            if (!SecMasterUserResources.Contains(userResource.Resource))
                                SecMasterUserResources.Add(userResource.Resource);
                            break;
                    }
                    //                    if(userResource.Resource is ResPoliclinic)
                    //                    {
                    //                        if(((ResPoliclinic)userResource.Resource).PatientCallSystemInUse == true)
                    //                        {
                    //                            foreach(ExaminationQueueDefinition queue in ((ResPoliclinic)userResource.Resource).AppointmentQueueDefinition)
                    //                            {
                    //                                UserQueues.Add(queue);
                    //                            }
                    //                        }
                    //                    }
                }
            }

            OutPatientUserResources = OutPatientUserResources.OrderBy(r => r.Name).ToList();
            InPatientUserResources = InPatientUserResources.OrderBy(r => r.Name).ToList();
            SecMasterUserResources = SecMasterUserResources.OrderBy(r => r.Name).ToList();
        }
        //private List<ResSection> _selectedResources = new List<ResSection>();
        private ResSection _selectedInPatientResource;
        public ResSection SelectedInPatientResource
        {
            get
            {
                if (_selectedInPatientResource == null)
                {
                    var uo = GetUserOption(UserOptionType.SelectedInPatientResource);
                    if (uo != null)
                    {
                        _selectedInPatientResource = ObjectContext.GetObject<ResSection>(new Guid(uo.Value), false);
                    }
                }
                if (_selectedInPatientResource == null)
                    _selectedInPatientResource = GetSelectedResource(ResourceEnableType.InPatient);
                return _selectedInPatientResource;
            }
            set
            {
                _selectedInPatientResource = value;
                Guid g = Guid.Empty;
                if (value != null)
                    g = value.ObjectID;
                SaveUserOption(UserOptionType.SelectedInPatientResource, g.ToString());
                //_selectedResources.Add(_selectedInPatientResource);
            }
        }

        private ResSection _selectedOutPatientResource;
        public ResSection SelectedOutPatientResource
        {
            get
            {
                if (_selectedOutPatientResource == null)
                {
                    var uo = GetUserOption(UserOptionType.SelectedOutPatientResource);
                    if (uo != null)
                    {
                        _selectedOutPatientResource = ObjectContext.GetObject<ResSection>(new Guid(uo.Value), false);
                    }
                }
                if (_selectedOutPatientResource == null)
                    _selectedOutPatientResource = GetSelectedResource(ResourceEnableType.OutPatient);
                return _selectedOutPatientResource;
            }
            set
            {
                _selectedOutPatientResource = value;
                Guid g = Guid.Empty;
                if (value != null)
                    g = value.ObjectID;
                SaveUserOption(UserOptionType.SelectedOutPatientResource, g.ToString());
                //_selectedResources.Add(_selectedOutPatientResource);
            }
        }

        private ResSection _selectedSecMasterResource;
        public ResSection SelectedSecMasterResource
        {
            get
            {
                if (_selectedSecMasterResource == null)
                {
                    var uo = GetUserOption(UserOptionType.SelectedSecMasterResource);
                    if (uo != null)
                    {
                        _selectedSecMasterResource = ObjectContext.GetObject<ResSection>(new Guid(uo.Value), false);
                    }
                }
                if (_selectedSecMasterResource == null)
                    _selectedSecMasterResource = GetSelectedResource(ResourceEnableType.Secmaster);
                return _selectedSecMasterResource;
            }
            set
            {
                _selectedSecMasterResource = value;
                Guid g = Guid.Empty;
                if (value != null)
                    g = value.ObjectID;
                SaveUserOption(UserOptionType.SelectedSecMasterResource, g.ToString());
                //_selectedResources.Add(_selectedSecMasterResource);
            }
        }

        public List<ResSection> SelectedResources
        {
            get
            {
                List<ResSection> _selectedResources = new List<ResSection>();
                if (SelectedInPatientResource != null)
                    _selectedResources.Add(SelectedInPatientResource);
                if (SelectedOutPatientResource != null)
                    _selectedResources.Add(SelectedOutPatientResource);
                if (SelectedSecMasterResource != null)
                    _selectedResources.Add(SelectedSecMasterResource);
                return _selectedResources;
            }
            //set { _selectedResources = value; }
        }


        List<ResSection> _selectedWorkListResources = new List<ResSection>();
        public List<ResSection> SelectedWorkListResources
        {
            get
            {
                if (_selectedWorkListResources == null || _selectedWorkListResources.Count <= 0)
                    return SelectedResources;
                return _selectedWorkListResources;
            }
            set { _selectedWorkListResources = value; }
        }

        private ExaminationQueueDefinition _selectedQueue;
        public ExaminationQueueDefinition SelectedQueue
        {
            get
            {
                bool maxDateUsed = false;
                if (TTObjectClasses.SystemParameter.GetParameterValue("GETWORKINGRESOURCESBYMAXQUEUEDATE", "FALSE") != "FALSE")
                {
                    maxDateUsed = true;
                    if (_selectedQueue == null)
                    {
                        var uo = GetUserOption(UserOptionType.SelectedQueue);
                        if (uo != null)
                        {
                            _selectedQueue = ObjectContext.GetObject<ExaminationQueueDefinition>(new Guid(uo.Value), false);
                        }
                    }
                    if (_selectedQueue == null)
                        _selectedQueue = GetMyCurrentQueue(maxDateUsed);
                }
                else
                    _selectedQueue = GetMyCurrentQueue(maxDateUsed);
                return _selectedQueue;
            }
            set
            {
                _selectedQueue = value;
                Guid g = Guid.Empty;
                if (value != null)
                    g = value.ObjectID;

                TTObjectContext objectContext = new TTObjectContext(false);

                //Doktorun bugünkü kuyruk çalışma planları varsa çek, hepsinin isActive ini false yap.
                BindingList<QueueResourceWorkPlanDefinition> queueResourceWorkPlanDefinitions = QueueResourceWorkPlanDefinition.GetTodaysQueueOfResource(objectContext, TTObjectClasses.Common.RecTime().Date, ObjectID);
                foreach (QueueResourceWorkPlanDefinition queueResourceWorkPlan in queueResourceWorkPlanDefinitions)
                {
                    queueResourceWorkPlan.IsActive = false;
                }
                //Doktor birimini seçtiğinde Kaynak-Kuyruk çalışma planı tanımlarına eklensin.
                if (_selectedQueue != null)
                {
                    QueueResourceWorkPlanDefinition queueResourceWorkPlanDefinition = (QueueResourceWorkPlanDefinition)objectContext.CreateObject(typeof(QueueResourceWorkPlanDefinition).Name);
                    queueResourceWorkPlanDefinition.IsActive = true;
                    queueResourceWorkPlanDefinition.Queue = _selectedQueue;
                    queueResourceWorkPlanDefinition.Resource = this;
                    queueResourceWorkPlanDefinition.LastCallTime = TTObjectClasses.Common.RecTime();
                    DateTime dateTime = TTObjectClasses.Common.RecTime();
                    queueResourceWorkPlanDefinition.WorkDate = dateTime.Date;
                }
                objectContext.Save();
                SaveUserOption(UserOptionType.SelectedQueue, g.ToString());
            }
        }

        private ResSection _currentExaminationRoom;
        public ResSection CurrentExaminationRoom
        {
            get
            {
                if (_currentExaminationRoom == null)
                    _currentExaminationRoom = GetMyCurrentExaminationRoom();
                return _currentExaminationRoom;
            }
            set
            {
                _currentExaminationRoom = value;
            }
        }

        public BindingList<ExaminationQueueDefinition> MyActiveQueues()
        {
            List<Guid> polGUIDs = new List<Guid>();
            if (SelectedOutPatientResource != null)
            {
                if (SelectedOutPatientResource is ResDepartment)
                {
                    foreach (ResPoliclinic pol in ((ResDepartment)SelectedOutPatientResource).Policlinics)
                    {
                        if (pol.PatientCallSystemInUse == true)
                        {
                            polGUIDs.Add(pol.ObjectID);
                        }
                    }
                    foreach (ResClinic clinic in ((ResDepartment)SelectedOutPatientResource).Clinics)
                    {
                        polGUIDs.Add(clinic.ObjectID);
                    }
                }
                else if (SelectedOutPatientResource is ResPoliclinic)
                {
                    if (((ResPoliclinic)SelectedOutPatientResource).PatientCallSystemInUse == true)
                        polGUIDs.Add(SelectedOutPatientResource.ObjectID);
                }
                else if (SelectedOutPatientResource is ResClinic)
                    polGUIDs.Add(SelectedOutPatientResource.ObjectID);
            }

            if (polGUIDs.Count == 0)
            {
                polGUIDs.Add(Guid.Empty);
            }
            BindingList<ExaminationQueueDefinition> queueList = ExaminationQueueDefinition.GetQueuesByResources(ObjectContext, polGUIDs);
            return queueList;
        }

        public static BindingList<ExaminationQueueDefinition> MyActiveQueues(Resource outPatientResource)
        {
            List<Guid> polGUIDs = new List<Guid>();
            if (outPatientResource != null)
            {
                if (outPatientResource is ResDepartment)
                {
                    foreach (ResPoliclinic pol in ((ResDepartment)outPatientResource).Policlinics)
                    {
                        if (pol.PatientCallSystemInUse == true)
                        {
                            polGUIDs.Add(pol.ObjectID);
                        }
                    }
                    foreach (ResClinic clinic in ((ResDepartment)outPatientResource).Clinics)
                    {
                        polGUIDs.Add(clinic.ObjectID);
                    }
                }
                else if (outPatientResource is ResPoliclinic)
                {
                    if (((ResPoliclinic)outPatientResource).PatientCallSystemInUse == true)
                        polGUIDs.Add(outPatientResource.ObjectID);
                }
                else if (outPatientResource is ResClinic)
                    polGUIDs.Add(outPatientResource.ObjectID);
                else if (outPatientResource is ResObservationUnit)
                    polGUIDs.Add(outPatientResource.ObjectID);

            }

            if (polGUIDs.Count == 0)
            {
                polGUIDs.Add(Guid.Empty);
            }
            TTObjectContext context = new TTObjectContext(false);
            BindingList<ExaminationQueueDefinition> queueList = ExaminationQueueDefinition.GetQueuesByResources(context, polGUIDs);
            return queueList;
        }

        private ExaminationQueueDefinition GetMyCurrentQueue(bool maxDateUsed)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            IList queueResourceList;
            if (maxDateUsed)
                queueResourceList = QueueResourceWorkPlanDefinition.GetAllQueuesOfResource(objectContext, ObjectID);
            else
                queueResourceList = QueueResourceWorkPlanDefinition.GetTodaysQueueOfResource(objectContext, Common.RecTime().Date, ObjectID);
            if (queueResourceList.Count > 0)
            {
                return ((QueueResourceWorkPlanDefinition)queueResourceList[0]).Queue;
            }
            else
                return null;
        }

        private ResSection GetMyCurrentExaminationRoom()
        {
            TTObjectContext context = ObjectContext;
            IBindingList compList = AppointmentViewerCompDef.GetAppointmentViewerCompDef(null);
            foreach (AppointmentViewerCompDef.GetAppointmentViewerCompDef_Class appCompDefcs in compList)
            {
                if (appCompDefcs.ComputerName == TTObjectClasses.Common.GetCurrentUserComputerName())
                {
                    AppointmentViewerCompDef appCompDef = (AppointmentViewerCompDef)context.GetObject((Guid)appCompDefcs.ObjectID, typeof(AppointmentViewerCompDef).Name);
                    foreach (RelatedResource res in appCompDef.RelatedResources)
                    {
                        if (res.Resource is ResSection)
                            return res.Resource;
                    }
                }
            }
            return null;
        }

        public bool IsEmergencyUser
        {
            get
            {
                bool isEmergenceClinic = false;
                if (SelectedInPatientResource is ResClinic)
                {
                    if (((ResClinic)SelectedInPatientResource).IsEmergencyClinic == true)
                    {
                        isEmergenceClinic = true;
                    }

                }
                if (isEmergenceClinic == false)
                {
                    if (SelectedOutPatientResource is ResClinic)
                    {
                        if (((ResClinic)SelectedOutPatientResource).IsEmergencyClinic == true)
                        {
                            isEmergenceClinic = true;
                        }
                    }
                }

                if (isEmergenceClinic)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IList<CashOfficeComputerUserDefinition> GetUserCashOfficeComputerDefinitions(ResUser currentUser)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            return CashOfficeComputerUserDefinition.GetByUserID(objectContext, currentUser.ObjectID);
        }

        //private CashierLog _myCLog = null;
        public CashierLog GetOpenCashCashierLog()
        {
            CashierLog _myCLog = null;
            CashOfficeComputerUserDefinition _myCCUser = null;
            string currentComputerName = Common.GetCurrentUserComputerName();
            //     IList cCUserList = CashOfficeComputerUserDefinition.GetByUserNameCompName(this.ObjectContext,this.ObjectID.ToString(),"username");
            IList cCUserList = CashOfficeComputerUserDefinition.GetByUserNameCompName(ObjectContext, ObjectID.ToString(), currentComputerName);
            if (cCUserList.Count > 0)
                _myCCUser = (CashOfficeComputerUserDefinition)cCUserList[0];


            if (_myCCUser != null)
            {
                IList cLogList = CashierLog.GetOpenLogByUserAndCashOffice(ObjectContext, ObjectID.ToString(), _myCCUser.CashOffice.ObjectID.ToString());
                if (cLogList.Count > 0)
                    _myCLog = (CashierLog)cLogList[0];
            }
            return _myCLog;
        }

        private ResSection GetSelectedResource(ResourceEnableType resType)
        {
            foreach (UserResource userResource in UserResources)
            {
                switch (userResource.Resource.EnabledType)
                {
                    case ResourceEnableType.BothInpatientAndOutPatient:
                        return userResource.Resource;
                    case ResourceEnableType.InPatient:
                        if (resType == ResourceEnableType.InPatient)
                            return userResource.Resource;
                        break;
                    case ResourceEnableType.OutPatient:
                        if (resType == ResourceEnableType.OutPatient)
                            return userResource.Resource;
                        break;
                    case ResourceEnableType.Secmaster:
                        if (resType == ResourceEnableType.Secmaster)
                            return userResource.Resource;
                        break;
                }
            }

            return null;
        }

        public string GetCardDrawerFilter(string filter)
        {
            if (SecMasterUserResources == null)
                return "1 = 2";

            string retValue = string.Empty;
            List<Guid> ids = new List<Guid>();
            foreach (Resource resource in SecMasterUserResources)
                if (resource is ResCardDrawer)
                    ids.Add(resource.ObjectID);
            if (ids.Count > 0)
            {
                retValue += filter + " (";
                int i = 1;
                foreach (Guid id in ids)
                {
                    retValue += ConnectionManager.GuidToString(id);
                    if (i != ids.Count)
                        retValue += ", ";
                    i++;
                }
                retValue += ") ";
            }
            else
            {
                retValue = "1 = 2";
            }

            return retValue;
        }

        public List<Store> SelectedStores
        {
            get
            {
                List<Store> stores = new List<Store>();
                foreach (ResSection resSection in SelectedResources)
                {
                    if (resSection.Store != null)
                    {
                        if (stores.Contains(resSection.Store) == false)
                            stores.Add(resSection.Store);
                    }
                }
                return stores;
            }
        }
        public void SendUserToPACS()
        {
            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
            if (sysparam == "TRUE")
            {
                bool hasDepartment = false;
                if (UserResources.Count > 0)
                    hasDepartment = true;
                if (hasDepartment)
                {
                    List<Guid> resUserIDs = new List<Guid>();
                    resUserIDs.Add(ObjectID);
                    try
                    {
                        //TTMessageFactory.SyncCall(Sites.SiteLocalHost, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", resUserIDs, "M02", "PACS");
                        //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, resUserIDs, "M02", "PACS");
                    }
                    catch (Exception ex)
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage("Hasta bilgileri PACS'a gönderilemedi! " + ex.Message);
                    }
                }
            }
        }

        public TTUser GetMyTTUser()
        {
            TTUser myTTUser = null;
            foreach (TTStorageManager.Security.TTUser u in TTUser.GetAllUsers())
            {
                if (u.TTObjectID.HasValue)
                {
                    if (u.TTObjectID == ObjectID)
                    {
                        myTTUser = u;
                        break;
                    }
                }
            }
            return myTTUser;
        }


        public static BindingList<ResUser> GetResUsersByRoleID(TTObjectContext context, Guid roleID)
        {
            TTUser myTTUser = null;
            BindingList<ResUser> resUserList = new BindingList<ResUser>();
            foreach (TTStorageManager.Security.TTUser u in TTUser.GetAllUsers())
            {
                if (u.AllRoles.ContainsKey(roleID))
                {
                    if (u.TTObjectID != null)
                    {
                        BindingList<ResUser> userList = ResUser.GetResUserByObjectID(context, u.TTObjectID.ToString());
                        foreach (ResUser ru in userList)
                            resUserList.Add(ru);
                    }
                }
            }
            return resUserList;
        }

        //public class SimpleResUserInfo
        //{
        //    public string ExternalID;
        //    public string Name;
        //    public string SurName;
        //    public long? UniqueRefNo;
        //}

        /*
        "select * from cashofficecomputer where computer='" & GetComputerName & "' "
        SQL = SQL & " and userId = " & CurrentUser.ID & " "
            
            
            
        SQL = "select * from cashierlog where cashierid=" & Me.ID
        SQL = SQL & " and Closingdate is NULL and cashierofficeid = " & h.GetComputerCashOfficeId
    
         */

        public byte[] SignData(object data)
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsaCryptoServiceProvider = new System.Security.Cryptography.RSACryptoServiceProvider();
            rsaCryptoServiceProvider.PersistKeyInCsp = true;
            rsaCryptoServiceProvider.FromXmlString(UserDigitalSignature.GeneralSignature.ToString());
            rsaCryptoServiceProvider.FromXmlString(UserDigitalSignature.PrivateSignature.ToString());
            byte[] originalData = TTUtils.SerializationHelper.SerializeObject(data);
            return rsaCryptoServiceProvider.SignData(originalData, 0, originalData.Length, new System.Security.Cryptography.SHA1CryptoServiceProvider());
        }

        public bool VerifySignedData(object data, byte[] signedData)
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsaCryptoServiceProvider = new System.Security.Cryptography.RSACryptoServiceProvider();
            rsaCryptoServiceProvider.PersistKeyInCsp = true;
            rsaCryptoServiceProvider.FromXmlString(UserDigitalSignature.GeneralSignature.ToString());
            return rsaCryptoServiceProvider.VerifyData(TTUtils.SerializationHelper.SerializeObject(data), new System.Security.Cryptography.SHA1CryptoServiceProvider(), signedData);
        }

        public AccountPayableReceivable MyAPR()
        {
            if (APR.Count == 0)
                ControlAndCreateAPR();

            return APR[0];
        }

        public void ControlAndCreateAPR()
        {
            if (APR.Count > 0)
                return;

            AccountPayableReceivable apr = new AccountPayableReceivable(ObjectContext);
            apr.Type = APRTypeEnum.USER;
            apr.Name = Name;
            apr.Balance = 0;
            apr.ResUser = this;
        }

        public SpecialityDefinition GetSpeciality()
        {
            if (ResourceSpecialities.Count > 0)
            {
                if (ResourceSpecialities.Count > 1)
                {
                    foreach (ResourceSpecialityGrid sp in ResourceSpecialities)
                    {
                        if (sp.MainSpeciality != null)
                        {
                            if (sp.MainSpeciality.Value == true && sp.Speciality != null)
                                return sp.Speciality;
                        }
                    }
                }

                if (ResourceSpecialities[0].Speciality != null)
                    return ResourceSpecialities[0].Speciality;
            }

            return null;
        }

        public bool IsAuthorizedResourceOfPatient(Patient patient)
        {
            foreach (Episode episode in patient.Episodes)
            {
                foreach (PatientAuthorizedResource patientAuthRes in episode.PatientAuthorizedResources)
                {
                    if (patientAuthRes.Resource != null && patientAuthRes.Resource.ObjectID == ObjectID)
                        return true;
                }
            }
            return false;
        }

        public bool IsAuthorizedResourceOfEpisode(Episode episode)
        {
            if (episode == null)
                return false;

            if (episode.PatientAuthorizedResources.Count < 1) // eğer hiç vakada sorumlu doktor yoksa gelen kullanıcı sorumlu doktor gibi davranabilsin.
            {
                return true;
            }
            foreach (PatientAuthorizedResource patientAuthRes in episode.PatientAuthorizedResources)
            {
                if (patientAuthRes.Resource != null && patientAuthRes.Resource.ObjectID == ObjectID)
                    return true;
            }
            return false;
        }

        public bool IsPatientSecureAndHasNoRightOfUser(IEpisodeActionPermission episodeAction)
        {
            if (episodeAction.GetEpisode() != null && (episodeAction.GetEpisode().Patient.SecurePerson == null || episodeAction.GetEpisode().Patient.SecurePerson.Value != true))// hasta vip değil
                return false;
            if (Common.IsAttributeExistsV2(typeof(UseStandartPermissionForSecurePersonAttribute), episodeAction.GetObjectDef())) // Hasta vip bile olsa  bu attribute varsa yetkiler normal hasta gibi çalışır
                return false;
            if (IsAuthorizedResourceOfEpisode(episodeAction.GetEpisode()))
                return false;
            if (Common.OverridePrintRoles(GetMyTTUser()) == true)
                return false;
            return true;
        }

        public bool IsPrivateSpecialityAndHasRightOfUser(IEpisodeActionPermission episodeAction)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("CHECKIFSPECIALITYISPRIVATE", "TRUE") == "FALSE")
                return true;

            bool foundPrivateSpeciality = false;
            foreach (ResourceSpecialityGrid resourceSpeciality in episodeAction.GetMasterResource().ResourceSpecialities)
            {
                if (resourceSpeciality.Speciality.IsPrivate == true)
                {
                    foundPrivateSpeciality = true;
                    foreach (UserResource userResource in UserResources)
                    {
                        if (userResource.Resource != null)
                        {
                            foreach (ResourceSpecialityGrid userResourceSpeciality in userResource.Resource.ResourceSpecialities)
                            {
                                if (resourceSpeciality.Speciality.ObjectID.Equals(userResourceSpeciality.Speciality.ObjectID))
                                    return true;
                            }
                        }
                    }
                }
            }

            if (foundPrivateSpeciality == true)
                return false;
            return true;
        }

        public bool IsAssignablePatientGroup(Episode episode)
        {
            bool checkIsAssignable = false;

            if (ResUserPatientGroupMatches == null) return true;

            if (ResUserPatientGroupMatches.Count == 0) return true;
            else
            {
                BindingList<ResUserPatientGroupMatch> AssignableMatchList = ResUserPatientGroupMatches.Select("ISASSIGNABLE = 1");
                if (AssignableMatchList.Count > 0)
                {
                    foreach (ResUserPatientGroupMatch match in AssignableMatchList)
                    {
                        /*  if (match.PatientGroup.PatientGroupEnum == episode.Patient.PatientGroup)
                          {
                              checkIsAssignable = true;
                              return checkIsAssignable;
                          }*/
                    }
                }

                BindingList<ResUserPatientGroupMatch> NotAssignableMatchList = ResUserPatientGroupMatches.Select("ISASSIGNABLE = 0");
                if (NotAssignableMatchList.Count > 0)
                {
                    foreach (ResUserPatientGroupMatch match in NotAssignableMatchList)
                    {
                        /*if (match.PatientGroup.PatientGroupEnum == episode.Patient.PatientGroup)
                        {
                            checkIsAssignable = false;
                            return checkIsAssignable;
                        }*/
                    }
                }

            }

            return checkIsAssignable;
        }

        //Gizli hastalarda personele çıkacak uyarı bilgilendirme ekranında bir daha gösterme check i işaretlendiyse, o hasta için uyarı ekranı tekrar gelmesin diye hasta objectID sini tutan liste.
        public List<Guid> PrivacyPatientNotShownList = new List<Guid>();


        /// <summary>
        /// Kullanıcıya ait,o anki bilgisayarda, birden çok vezne tanımı var ise vezne seçimi yaptırır. Tek bir tane ise o tanımı getirir. Diğer durumlarda hata döndürür.
        /// </summary>
        /// <param name="parent">Seçim menüsünün açılacağı form.</param>
        /// <returns></returns>
        public static CashOfficeDefinition SelectCurrentUserCashOffice(CashOfficeTypeEnum cashOfficeType, ResUser currentUser)
        {
            List<CashOfficeComputerUserDefinition> cashOfficeCompUserList = new List<CashOfficeComputerUserDefinition>();
            //Kullanıcıya ait bulunduğu bilgisayar ile eşleşen CashOfficeComputer tanımları.
            if (currentUser != null)
                cashOfficeCompUserList = currentUser.GetUserCashOfficeComputerDefinitions(currentUser).Where(x => /*x.ComputerName == Common.GetCurrentUserComputerName() &&*/ x.CashOffice.Type == cashOfficeType).ToList();
            else
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25301", "Bu bilgisayarda işlem yapabilmek için size tanımlanmış bir vezne bulunmamaktadır."));

            //CashOfficeComputerUser bilgisayar adı ile eşleşen kayıt.
            if (cashOfficeCompUserList.Count > 0)
            {
                //TODO: Vezne seçimi.
                /*MultiSelectForm multiSelectForm;
                if (cashOfficeCompUserList.Count > 1)
                {
                    multiSelectForm = new MultiSelectForm();
                    foreach (CashOfficeComputerUserDefinition receiptCOCU in cashOfficeCompUserList)
                        multiSelectForm.AddMSItem(receiptCOCU.CashOffice.Name, receiptCOCU.ObjectID.ToString(), receiptCOCU);
                    multiSelectForm.AccessType = ListPropertyDefAccessEnum.Full;
                    multiSelectForm.GetMSItem(parent, "Vezne seçiniz.", false, false, false, false, true);
                    if (multiSelectForm.DialogResult != DialogResult.Cancel)
                        return ((CashOfficeComputerUserDefinition)multiSelectForm.MSSelectedItemObject).CashOffice;
                    else
                        throw new TTException("İşlemden vazgeçildi.");
                }*/
                //else
                return cashOfficeCompUserList[0].CashOffice;
            }
            else
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27191", "Vezne / Fatura Servisi Bilgisayar Kullanıcı Tanımı mevcut değil."));
        }

        public static String GetAnaUzmanlikBrans(ResUser user, string type)
        {
            bool ctrl = false;
            foreach (ResourceSpecialityGrid resource in user.ResourceSpecialities)
            {
                if (resource.MainSpeciality != null && resource.MainSpeciality.Equals(true))
                {
                    if (resource.Speciality != null && resource.Speciality.Code != null)
                    {
                        ctrl = true;
                        return resource.Speciality.Code;
                    }
                }
            }
            if (!ctrl)
            {
                throw new Exception(type + " tedavi eden doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
            }
            return null;
        }

        public String GetSpecialityName()
        {
            string speciality = string.Empty;
            foreach (var resourceSpeciality in ResourceSpecialities)
            {
                if (resourceSpeciality.Speciality != null)
                {
                    if (!String.IsNullOrEmpty(speciality))
                        speciality += ",";
                    speciality += resourceSpeciality.Speciality.Name;
                }
            }
            return speciality;
        }

        public static bool HasRole(ResUser resUser, Guid roleID)
        {
            TTUser ttUser = resUser.GetMyTTUser();
            if (ttUser == null)
                return false;
            return ttUser.AllRoles.ContainsKey(roleID);
        }

        public string GetResUserByPACount()
        {
            if (PACount == null)
            {
                return Name;
            }
            else
            {
                if (PACount.PatientAdmissionDate.Value.Date == Common.RecTime().Date)
                    return Name + " ( " + PACount?.Counter + " / " + DoctorQuota?.Quota + " ) ";
                else
                    return Name;
            }
            //BindingList<ResUser.SpecialistDoctorListForPANQL_Class> userList = ResUser.SpecialistDoctorListForPANQL(Common.RecTime().Date, Common.RecTime().AddDays(1).Date,this.ObjectID);
            //if (userList.Count > 0)
            //{
            //    return userList[0].Counter == 0 ? userList[0].Name : userList[0].Name + " ( " + userList[0].Counter + " )";
            //}
            //else
            //    return this.Name;
        }

        public RequirementResultCode IsUserAvailableToNotWork(DateTime startDateTime, DateTime endDateTime, MHRSActionTypeDefinition MHRSActionType, bool addNonWorkingHour)
        {
            RequirementResultCode result = new RequirementResultCode();
            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    string startDateStr = startDateTime.ToLongDateString();
                    string endDateStr = endDateTime.ToLongDateString();
                    //Kullanıcının verilen tarih aralığında randevusu var mı diye bakılır. Varsa false döner.
                    BindingList<Appointment.GetUserAppointmentsByDateTime_Class> userAppList = Appointment.GetUserAppointmentsByDateTime(startDateTime, endDateTime, ObjectID);
                    if (userAppList.Count > 0)
                    {
                        result.ErrorMessage = Name + " adlı personelin " + startDateStr + " - " + endDateStr + " tarihleri arasında randevusu bulunmaktadır.";
                        result.IsSuccess = false;
                        return result;
                    }

                    //Kullanıcının verilen tarih aralığında planlaması var mı diye bakılır. Yoksa true döner.
                    BindingList<Schedule> scheduleList = Schedule.GetUserSchedulesByDateTime(objectContext, startDateTime, endDateTime, ObjectID);
                    if (scheduleList.Count > 0)
                    {
                        //Schedule ı varsa
                        foreach (Schedule sch in scheduleList)
                        {
                            //Sağlam olsun diye bu schedule a ait randevu var mı diye bakılır. Varsa false döner.
                            BindingList<Appointment> appointmentList = Appointment.GetBySchedule(ObjectContext, sch.ObjectID.ToString());
                            if (appointmentList.Count > 0)
                            {
                                result.ErrorMessage = Name + " adlı personelin " + startDateStr + " - " + endDateStr + " tarihleri arasında randevusu bulunmaktadır.";
                                result.IsSuccess = false;
                                return result;
                            }
                            //Bu schedule a ait randevu yoksa ve silinebiliyorsa schedule silinir.
                            if (sch.isRemovable())
                                ((ITTObject)sch).Delete();
                        }
                    }
                    objectContext.Save();
                    //Verilen tarih aralığı için çalışılmayan saat planlaması yapılır.
                    if (addNonWorkingHour)
                    {
                        Schedule.CreateScheduleForNonWorkingHour(startDateTime, endDateTime, MHRSActionType, this);
                        result.SuccessMessage = Name + " adlı personelin izin bilgisi başarıyla eklenmiştir.";
                    }
                    else
                        result.SuccessMessage = Name + " adlı personelin izin bilgisi başarıyla iptal edilmiştir.";
                    result.IsSuccess = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = Name + " adlı personel izin hatası : " + ex.ToString();
                return result;
            }
        }

        public static bool ChangeKPSPassword(Guid userID, string oldPassword, string newPassword)
        {
            if (Common.CurrentUser.UserID != userID)
                throw new TTException("Kullanıcı sadece kendi şifresini değiştirebilir.");

            using (var context = new TTObjectContext(false))
            {
                TTUser ttuser = TTUser.GetUser(userID);

                if (ttuser != null && ttuser.TTObjectID.HasValue)
                {
                    string _id = ttuser.TTObjectID.HasValue ? ttuser.TTObjectID.Value.ToString() : "";
                    ResUser user = GetResUserByObjectID(context, _id)[0];

                    if (user != null)
                    {
                        user.KPSPassword = newPassword;
                        user.KPSUserName = oldPassword;//kullanıcı adı burda tutuldu

                        //user.ObjectContext.Save();
                        context.Save();

                        TTUser.CurrentUser.RefreshUserObject();
                    }
                }

            }

            return true;
        }
        #endregion Methods

    }
}