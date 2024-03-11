using AutoMapper;
using JWT_P2.DTOs.Schools;
using JWT_P2.Models;
using JWT_P2.Repositories.SchoolsRepo;
using JWT_P2.Services.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JWT_P2.Services.SchoolServ
{
    public class SchoolsService : ICommonService<SchoolsGetDTO, SchoolsPostDTO, SchoolsPutDTO>
    {

        private ISchoolsRepository _schoolsRpository;
        private IMapper _schoolsMappingProfile;

        public SchoolsService
            (
                [FromKeyedServices("schoolsRepository")]ISchoolsRepository schoolsRpository,
                IMapper schoolsMappingProfile
            ) 
        {
            _schoolsRpository = schoolsRpository;
            _schoolsMappingProfile = schoolsMappingProfile;
        }

        public async Task<IEnumerable<SchoolsGetDTO>> GetElements()
        {
            var schools = await _schoolsRpository.GetElementsFromRepository();
            var schoolsDTO = schools.Select(school => _schoolsMappingProfile.Map<SchoolsGetDTO>(school));
            return schoolsDTO;
        }

        public async Task<SchoolsGetDTO> GetElementById(Guid id)
        {
            var school = await _schoolsRpository.GetElementByIdFromRepository(id);
            if (school == null) return null;

            var schoolDTO = _schoolsMappingProfile.Map<SchoolsGetDTO>(school);
            return schoolDTO;
        }

        public IEnumerable<SchoolsGetDTO> GetElementByName(string name)
        {
            var schools = _schoolsRpository.GetElementByNameFromRepository(name);
            var schoolDTO = schools.Select(school => _schoolsMappingProfile.Map<SchoolsGetDTO>(school));
            return schoolDTO;
        }

        public async Task<SchoolsGetDTO> PostElement(SchoolsPostDTO tPostDTO)
        {
            var school = _schoolsMappingProfile.Map<Schools>(tPostDTO);

            await _schoolsRpository.AddSchool(school);
            await _schoolsRpository.SaveAsync();

            var schoolDTO = _schoolsMappingProfile.Map<SchoolsGetDTO>(school);
            return schoolDTO;
        }

        public async Task<SchoolsGetDTO> PutElement(SchoolsPutDTO tPutDTO)
        {
            var school = await _schoolsRpository.GetElementByIdFromRepository(tPutDTO.Id);
            if (school == null) return null;

            school = _schoolsMappingProfile.Map<SchoolsPutDTO, Schools>(tPutDTO, school);

            _schoolsRpository.UpdateSchool(school); 
            await _schoolsRpository.SaveAsync();

            var schoolDTO = _schoolsMappingProfile.Map<SchoolsGetDTO>(school);

            return schoolDTO;            
        }

        public async Task<SchoolsGetDTO> DeleteElement(Guid id)
        {
            var school = await _schoolsRpository.GetElementByIdFromRepository(id);
            if (school == null) return null;

            _schoolsRpository.DeleteSchool(school);
            await _schoolsRpository.SaveAsync();

            var schoolDTO = _schoolsMappingProfile.Map<SchoolsGetDTO>(school);
            return schoolDTO;

        }
    }
}
