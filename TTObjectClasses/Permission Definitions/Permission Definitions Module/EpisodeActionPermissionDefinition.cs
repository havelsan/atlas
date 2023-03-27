
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


namespace TTStorageManager.Security
{

    public partial class EpisodeActionPermissionDefinition : TTSecurityAuthority
    {
#region Body
            private const int WORKLIST_RIGHT = 1001;

        protected bool CheckAuthorizedUser(IEpisodeActionPermission episodeAction, ResUser currentUser)
        {
            if (episodeAction.GetProcedureDoctor() != null && currentUser.ObjectID.Equals(episodeAction.GetProcedureDoctor().ObjectID))
                return true;
            foreach (AuthorizedUser authorizedUser in episodeAction.GetAuthorizedUsers())
            {
                if (authorizedUser.User != null && authorizedUser.User.ObjectID == currentUser.ObjectID)
                    return true;
            }
            return false;
        }

        protected override bool HasRight(TTUser user, object securableObjectInstance)
        {
            if (securableObjectInstance == null)
                return true;

            TTObject ttObject = securableObjectInstance as TTObject;
            if (ttObject == null)
            {
                //TODO: Server-client calismasinda commentlendi. securableObjectInstance in TTForm olup olmadigi kontrol daha sonra farkli bir yontem ile bakilacak.
                //if (securableObjectInstance is TTVisual.TTForm)
                //    ttObject = ((TTVisual.TTForm)securableObjectInstance)._ttObject as TTObject;
            }
            if (ttObject != null)
            {
                IEpisodeActionPermission episodeAction = ttObject as IEpisodeActionPermission;
                ResUser currentUser = user.UserObject as ResUser;
                bool isWorkListRight = (CurrentPermission.RightDef.RightDefID == WORKLIST_RIGHT);
                bool isReadFormRight = (CurrentPermission.RightDef.RightDefID == 50); // ReadForm
                bool isPatientSecureAndHasNoRightOfCurrentUser = currentUser.IsPatientSecureAndHasNoRightOfUser(episodeAction);
                
                //Güvenlikli kullanıcılar için
                if (episodeAction.GetCurrentStateDef().Status == StateStatusEnum.CompletedSuccessfully)// tamamlanmış işlemlerde
                {
                    if (isReadFormRight) // Kullanıcı Patientın PatientAuthorizedResourcelarından biriyse (Açık Yada Açık Devam Episodeda sorunlu doktor ise)  tüm işlemlerin son adımlarını read edebilir
                    {
                        
                        if (isPatientSecureAndHasNoRightOfCurrentUser)// hasta vib'se ve kullanıcının episode sorumlu doktor olarak yetkisi yoksa mutlaka false dönecek
                        {
                            return false;
                        }

                        bool isAuthorizedResourceOfPatient = currentUser.IsAuthorizedResourceOfPatient(episodeAction.GetEpisode().Patient);
                        bool isPrivateSpecialityAndHasRightOfUser = currentUser.IsPrivateSpecialityAndHasRightOfUser(episodeAction);
                        if (TTObjectClasses.SystemParameter.GetParameterValue("PermissionCheckForOnlyOpenEpisode", "FALSE") == "TRUE")//Sadece Açık vakalardaki işlemler
                        {
                            if (isPrivateSpecialityAndHasRightOfUser && isAuthorizedResourceOfPatient && episodeAction.GetEpisode().CurrentStateDefID == Episode.States.Open) // vip olmayan hastalar için, current user hastanın herhangi bir episode unda sorumlu doktor ise tüm işlemlerin son adımlarını görebilsin.
                                return true;
                        }
                        else
                        {
                            if (isPrivateSpecialityAndHasRightOfUser && isAuthorizedResourceOfPatient) // vip olmayan hastalar için, current user hastanın herhangi bir episode unda sorumlu doktor ise tüm işlemlerin son adımlarını görebilsin.
                                return true;
                        }
                    }
                }
                //AuthorizedUser kullanılmamaya karar verilmiş. Bu yüzden işlemlerde authorizedUser set edilmemiş. Ama yetkilerde işaretli kalmış. Yetkilerde sorun çıkarıyordu o yüzden kaldırdım. BB
                //if (this.AuthorizedUser.HasValue)
                //{
                //    if (this.AuthorizedUser == true && isWorkListRight)// && SessionExtension.GetFromSession<Boolean>("OnlyAuthorizedUser"))
                //    {
                //        return CheckAuthorizedUser(episodeAction, currentUser);
                //    }
                //}
                if (Hospital.HasValue && Hospital.Value)
                    return true;

                if (MasterResource.HasValue && MasterResource.Value)
                {
                    Guid? resID = (Guid?)ttObject["MASTERRESOURCE"];
                    if (resID.HasValue == false)
                        return true;
                    //foreach (Resource uResource in currentUser.SelectedResources)
                    //{
                    //    if (uResource.ObjectID == resID)
                    //        return true;
                    //}
                    foreach (UserResource userResource in currentUser.UserResources)
                    {
                        if (userResource.Resource.ObjectID == resID)
                            return true;
                    }
                }
                if (FromResource.HasValue && FromResource.Value)
                {
                    Guid? resID = (Guid?)ttObject["FROMRESOURCE"];
                    if (resID.HasValue == false)
                        return true;
                    //foreach (Resource uResource in currentUser.SelectedResources)
                    //{
                    //    if (uResource.ObjectID == resID)
                    //        return true;
                    //}
                    foreach (UserResource userResource in currentUser.UserResources)
                    {
                        if (userResource.Resource.ObjectID == resID)
                            return true;
                    }
                }
                if (SecondaryMasterResource.HasValue && SecondaryMasterResource.Value)
                {
                    Guid? resID = (Guid?)ttObject["SECONDARYMASTERRESOURCE"];
                    if (resID.HasValue)
                    {
                        //foreach (Resource uResource in currentUser.SelectedResources)
                        //{
                        //    if (uResource.ObjectID == resID)
                        //        return true;
                        //}
                        foreach (UserResource userResource in currentUser.UserResources)
                        {
                            if (userResource.Resource.ObjectID == resID)
                                return true;
                        }
                    }
                }


                if (AllocatedResource.HasValue && AllocatedResource.Value)
                {
                    foreach (Allocation allocation in episodeAction.GetEpisode().Allocations)
                    {
                        if (allocation.CurrentStateDefID == Allocation.States.Allocated)
                        {
                            if (allocation.Speciality != null)
                            {
                                foreach (SpecialityDefinition speciality in Common.CurrentResourceSpecialities())
                                {
                                    if (speciality.ObjectID == allocation.Speciality.ObjectID)
                                        return true;
                                }
                            }
                        }
                    }
                }

                if (AuthorizedUser.HasValue && AuthorizedUser.Value)
                    if (CheckAuthorizedUser(episodeAction, currentUser))
                        return true;


                if (EpisodeAuthorizedResource.HasValue && EpisodeAuthorizedResource.Value)
                {
                    foreach (PatientAuthorizedResource pAuthoRes in episodeAction.GetEpisode().PatientAuthorizedResources)
                    {
                        if (pAuthoRes.Resource != null)
                        {
                            if (pAuthoRes.Resource is ResUser)
                            {
                                if (pAuthoRes.Resource.ObjectID == currentUser.ObjectID && ((ResUser)pAuthoRes.Resource).IsPrivateSpecialityAndHasRightOfUser(episodeAction) == true)
                                    return true;
                            }
                            else
                            {
                                foreach (UserResource userResource in currentUser.UserResources)
                                {
                                    if (pAuthoRes.Resource.ObjectID == userResource.Resource.ObjectID)
                                        return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }


        private List<Guid> _WLAuthorizedUserStates;
        private List<Guid> _WLHospitalStates;
        private List<Guid> _WLMasterResourceStates;
        private List<Guid> _WLFromResourceStates;
        private List<Guid> _WLSecondaryMasterResourceStates;
        private List<Guid> _WLAllocatedResourceStates;
        private List<Guid> _WLEpisodeAuthorizedResourceStates;

        private void PrepareWorklistStateList(TTObjectStateDef stateDef)
        {
            //if (this.AuthorizedUser.HasValue && this.AuthorizedUser.Value)
            //{
            //    if (_WLAuthorizedUserStates == null)
            //        _WLAuthorizedUserStates = new List<Guid>();
            //    _WLAuthorizedUserStates.Add(stateDef.StateDefID);
            //    return;
            //}

            if (Hospital.HasValue && Hospital.Value)
            {
                if (_WLHospitalStates == null)
                    _WLHospitalStates = new List<Guid>();
                _WLHospitalStates.Add(stateDef.StateDefID);
                return;
            }

            if (MasterResource.HasValue && MasterResource.Value)
            {
                if (_WLMasterResourceStates == null)
                    _WLMasterResourceStates = new List<Guid>();
                _WLMasterResourceStates.Add(stateDef.StateDefID);
            }

            if (FromResource.HasValue && FromResource.Value)
            {
                if (_WLFromResourceStates == null)
                    _WLFromResourceStates = new List<Guid>();
                _WLFromResourceStates.Add(stateDef.StateDefID);
            }

            if (SecondaryMasterResource.HasValue && SecondaryMasterResource.Value)
            {
                if (_WLSecondaryMasterResourceStates == null)
                    _WLSecondaryMasterResourceStates = new List<Guid>();
                _WLSecondaryMasterResourceStates.Add(stateDef.StateDefID);
            }


            if (AllocatedResource.HasValue && AllocatedResource.Value)
            {
                if (_WLAllocatedResourceStates == null)
                    _WLAllocatedResourceStates = new List<Guid>();
                _WLAllocatedResourceStates.Add(stateDef.StateDefID);
            }

            if (AuthorizedUser.HasValue && AuthorizedUser.Value)
            {
                if (_WLAuthorizedUserStates == null)
                    _WLAuthorizedUserStates = new List<Guid>();
                _WLAuthorizedUserStates.Add(stateDef.StateDefID);
            }


            if (EpisodeAuthorizedResource.HasValue && EpisodeAuthorizedResource.Value)
            {
                if (_WLEpisodeAuthorizedResourceStates == null)
                    _WLEpisodeAuthorizedResourceStates = new List<Guid>();
                _WLEpisodeAuthorizedResourceStates.Add(stateDef.StateDefID);
            }

        }

        private void AppendStateListToExpression(StringBuilder expression, List<Guid> list)
        {
            expression.Append(" CURRENTSTATEDEFID IN(");
            string comma = "";
            foreach (Guid stateDefID in list)
            {
                expression.Append(comma);
                expression.Append(ConnectionManager.GuidToString(stateDefID));
                comma = ",";
            }
            expression.Append(") ");
        }

        private void AppendResourceControlToExpression(StringBuilder expression, List<Guid> list, StringBuilder resourceControl, string colName, bool addIsNull, ref string separetor)
        {
            expression.Append(separetor);
            separetor = " OR ";
            expression.Append(" (");
            AppendStateListToExpression(expression, list);
            if (addIsNull)
                expression.Append(" AND (" + colName + " IS NULL");
            else if (resourceControl.Length > 3)
                expression.Append(" AND (");
            else
                expression.Append(" AND (1=2");


            if (resourceControl.Length > 3)
            {
                if (addIsNull)
                    expression.Append(" OR ");

                expression.Append(colName + " IN(");
                expression.Append(resourceControl);
                expression.Append(")");
            }
            expression.Append(")");
            expression.Append(")");
        }

        public override void GetWorklistNQLFilter(StringBuilder expression, List<TTObjectStateDef> list)
        {
            if (TTUser.CurrentUser.IsSuperUser)
            {
                base.GetWorklistNQLFilter(expression, list);
                return;
            }

            int expressionLength = expression.Length;

            _WLAuthorizedUserStates = null;
            _WLHospitalStates = null;
            _WLMasterResourceStates = null;
            _WLFromResourceStates = null;
            _WLSecondaryMasterResourceStates = null;
            _WLAllocatedResourceStates = null;
            _WLEpisodeAuthorizedResourceStates = null;

            foreach (TTObjectStateDef stateDef in list)
            {
                ITTSecurableObject securableObject = stateDef.FormDef;
                TTPermissionCollection permissions;
                if (securableObject != null && securableObject.SubSecurityPermissions != null && securableObject.SubSecurityPermissions.TryGetValue(stateDef.StateDefID, out permissions))
                {
                    foreach (TTRoleMemberBase role in TTUser.CurrentUser.AllRoles.Values)
                    {
                        if (role.CheckForValidity() == false)
                            continue;
                        if (permissions.TryGetValue(role.RoleID, WORKLIST_RIGHT, out _currentPermission))
                            PrepareWorklistStateList(stateDef);
                    }
                }
            }

            string separator = "(";
            if (_WLHospitalStates != null)
            {
                expression.Append(separator);
                separator = " OR ";
                expression.Append(" (");
                AppendStateListToExpression(expression, _WLHospitalStates);
                expression.Append(")");
            }

            StringBuilder resourceControl = new StringBuilder("");
            if (_WLMasterResourceStates != null || _WLFromResourceStates != null || _WLSecondaryMasterResourceStates != null || _WLEpisodeAuthorizedResourceStates != null)
            {
                ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                string comma = "";
                foreach (Resource uResource in user.SelectedWorkListResources)
                {
                    resourceControl.Append(comma);
                    resourceControl.Append(ConnectionManager.GuidToString(uResource.ObjectID));
                    comma = ",";
                }

                //foreach (UserResource userResource in user.UserResources)
                //{
                //    resourceControl.Append(comma);
                //    resourceControl.Append(ConnectionManager.GuidToString(userResource.Resource.ObjectID));
                //    comma = ",";
                //}
            }

            if (_WLMasterResourceStates != null)
                AppendResourceControlToExpression(expression, _WLMasterResourceStates, resourceControl, "MASTERRESOURCE", true, ref separator);

            if (_WLFromResourceStates != null)
                AppendResourceControlToExpression(expression, _WLFromResourceStates, resourceControl, "FROMRESOURCE", true, ref separator);

            if (_WLSecondaryMasterResourceStates != null)
                AppendResourceControlToExpression(expression, _WLSecondaryMasterResourceStates, resourceControl, "SECONDARYMASTERRESOURCE", false, ref separator);

            if (_WLAuthorizedUserStates != null)
            {
                expression.Append(separator);
                separator = " OR ";
                expression.Append(" (");
                AppendStateListToExpression(expression, _WLAuthorizedUserStates);
                expression.Append(" AND AUTHORIZEDUSERS(USER=" + ConnectionManager.GuidToString(((ResUser)TTUser.CurrentUser.UserObject).ObjectID) + ").EXISTS");
                expression.Append(")");
            }

            if (_WLAllocatedResourceStates != null)
            {
                string specialities = "";
                string comma = "";
                foreach (SpecialityDefinition speciality in Common.CurrentResourceSpecialities())
                {
                    specialities += comma;
                    comma = ",";
                    specialities += ConnectionManager.GuidToString(speciality.ObjectID);
                }
                if (specialities.Length > 0)
                {
                    expression.Append(separator);
                    separator = " OR ";
                    expression.Append(" (");
                    AppendStateListToExpression(expression, _WLAllocatedResourceStates);

                    expression.Append(" AND THIS:EPISODE.ALLOCATIONS(CURRENTSTATE IS STATES.ALLOCATED AND SPECIALITY IN (" + specialities + ")).EXISTS");
                    expression.Append(")");
                }
            }

            if (_WLEpisodeAuthorizedResourceStates != null)
            {
                expression.Append(separator);
                separator = " OR ";
                expression.Append(" (");
                AppendStateListToExpression(expression, _WLEpisodeAuthorizedResourceStates);
                string episodeAuthorizedResources = ConnectionManager.GuidToString(((ResUser)TTUser.CurrentUser.UserObject).ObjectID);
                if (resourceControl.Length > 3)
                    episodeAuthorizedResources += "," + resourceControl.ToString();

                expression.Append(" AND THIS:EPISODE.PATIENTAUTHORIZEDRESOURCES(RESOURCE IN(" + episodeAuthorizedResources + ")).EXISTS");
                expression.Append(")");
            }

            if (expression.Length != expressionLength) //birşeyler eklenmiş parantezi kapat
                expression.Append(")");
        }
            
#endregion Body
    }
}