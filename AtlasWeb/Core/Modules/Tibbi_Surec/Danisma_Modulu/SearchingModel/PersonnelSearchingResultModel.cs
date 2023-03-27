using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Modules.Tibbi_Surec.Danisma_Modulu.SearchingModel
{
    public class PersonnelSearchingResultModel
    {
        public string Title
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string Department
        {
            get;
            set;
        }

        public string Mission
        {
            get;
            set;
        }

        public string Room
        {
            get;
            set;
        }
        public string WorkPlace
        {
            get;
            set;
        }

        public string RoomLocation
        {
            get;
            set;
        }

        public string RoomPhone
        {
            get;
            set;
        }

        public string Section
        {
            get;
            set;
        }

        public string MobilePhone
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }
        public long? UniqueRefNo
        {
            get;
            set;
        }
        public DateTime? DateOfJoin
        {
            get;
            set;
        }
        public DateTime? DateOfLeave
        {
            get;
            set;
        }

        public List <SectionResultModel> Sections { get; set; }
        public PersonnelSearchingResultModel(ResUser resUser)
        {

            if (resUser.Person != null)
            {
                Name = resUser.Person.Name;
                Surname = resUser.Person.Surname;
                MobilePhone = resUser.Person.MobilePhone;
                UniqueRefNo = resUser.Person.UniqueRefNo;
            }

            //if (resUser.AdministrativeStatusType != null)
            //{
            //     Mission = resUser.AdministrativeStatusType.Code.ToString();
            //}

            if(resUser.UserType != null)
            {
                Mission = Common.GetDisplayTextOfDataTypeEnum(resUser.UserType);

            }

            if (resUser.Title != null && resUser.Title != UserTitleEnum.Unused)
            {
                Title = Common.GetDisplayTextOfDataTypeEnum(resUser.Title);
            }

            RoomPhone = resUser.DeskPhoneNumber;
           // Department = resUser.Work;
            WorkPlace = resUser.WorkPlace;
            RoomLocation = resUser.Location;

            if (resUser.ResourceSpecialities.Count > 0)
            {
                foreach (var item in resUser.ResourceSpecialities)
                {
                    if(item.Speciality != null && item.Speciality.Name != null)
                        Department += item.Speciality.Name + ", ";
                }
                if(!String.IsNullOrEmpty(Department))
                    Department = Department.Remove(Department.LastIndexOf(','));

            }
            if (resUser.UserResources.Count > 0)
            {
                Sections = new List<SectionResultModel>();
                foreach (var item in resUser.UserResources)
                {
                    if (item.Resource != null && (item.Resource.ObjectDef.Name == "RESPOLICLINIC" || item.Resource.ObjectDef.Name == "RESCLINIC"))
                    {
                        SectionResultModel sectionResult = new SectionResultModel();
                        sectionResult.SectionName = item.Resource.Name;
                        sectionResult.SectionID = item.Resource.ObjectID;
                        
                        Section += item.Resource.Name;
                        if (item.Resource.IsActive == true)
                        {
                            Section += "(Aktif)";
                            sectionResult.SectionStatus = "Aktif";
                        }
                        else if (item.Resource.IsActive == false)
                        {
                            Section += "(Pasif)";
                            sectionResult.SectionStatus = "Pasif";

                        }
                        Section += ", ";

                        Section = Section.Remove(Section.LastIndexOf(','));
                        Sections.Add(sectionResult);
                    }
                }
            }

            DateOfJoin = resUser.DateOfJoin;
            DateOfLeave = resUser.DateOfLeave;
        }
    }
}

namespace Core.Models
{
    public class SectionResultModel
    {
        public string SectionName { get; set; }
        public string SectionStatus { get; set; }
        public Guid SectionID { get; set; }

    }
}