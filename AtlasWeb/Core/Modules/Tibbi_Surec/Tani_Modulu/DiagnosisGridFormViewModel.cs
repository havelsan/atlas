//$74B213F1
using TTObjectClasses;

namespace Core.Models
{
    public class DiagnosisGridFormViewModel
    {
        public object _selectedDiagnosis
        {
            get;
            set;
        }

        public string DiagnosisListFilterExpression;
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        //QuickSelection için 
        public TTObjectClasses.FavoriteDiagnosis[] FavoriteDiagnosisList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser_Class[] Top10DiagnosisDefinitionOfUserList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid.GetLast10DiagnosisOfPatient_Class[] Last10DiagnosisOfPatientList
        {
            get;
            set;
        }

        public vmEpisodeDiagnosisGrid[] EpisodeDiagnosisGridList
        {
            get;
            set;
        }
    }

    public class vmDiagnosisGridFormDefinitionsParameter
    {
        public TTObjectClasses.DiagnosisGrid[] GridDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }
    }


    public class vmNewDiagnosisGrid
    {
        public TTObjectClasses.DiagnosisGrid DiagnosisGrid
        {
            get;
            set;
        }
        public string StarterAction;
        public ResUser ResponsibleDoctor;
    }

    public class vmEpisodeDiagnosisGrid
    {
        public TTObjectClasses.DiagnosisGrid DiagnosisGrid
        {
            get;
            set;
        }
        public string DiagnoseName;
        public string DiagnoseObjectID;
        //public TTObjectClasses.DiagnosisDefinition Diagnose
        //{
        //    get;
        //    set;
        //}
    }

    public class DiagnoseObjectSelectionViewModel
    {
        public ENabizDataSets[] ENabizDataSets
        {
            get;
            set;
        }

        public DiagnosisActionSuggestionViewModel[] DiagnosisActionSuggestions
        {
            get;
            set;
        }

        public PhysicianSuggestionDefViewModel[] PhysicianSuggestionDefs
        {
            get;
            set;
        }

    }

    public class vmDiagnosisGridReadOnly
    {
        public string Diagnosis;
        public DiagnosisTypeEnum DiagnosisType ;
        public bool IsMainDiagnose;
        public string ResponsibleDoctor;
        public string EntryActionType;

    }


    public class DiagnosisActionSuggestionViewModel
    {
        public System.Guid? DiagnosisObjectId;
        public string ProcedureName;
        public System.Guid ProcedureObjectId;
        public System.Guid? ProcedureRequestFormDetailObjectId;
        public ActionTypeEnum ActionType;
        public bool ChoosedByUser;
        public bool CreateProcedure;
        public bool IsAdditionalApplication;
    }

    public class PhysicianSuggestionDefViewModel
    {
        public System.Guid? DiagnosisObjectId;
        public string GrupName;
        public System.Guid PhysicianSuggestionDefObjectId;
        public System.Guid? ParentPhysicianSuggestionDefObjectId;
        public string ReturnValueOfParent;
        public string Message;
        public string ButtonCaptions;
        public string ReturnValues;

        //Tetkik istem için 
        public DiagnosisActionSuggestionViewModel diagnosisActionSuggestionViewModel;
    }
}

