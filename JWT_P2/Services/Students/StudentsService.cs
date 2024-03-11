using AutoMapper;
using JWT_P2.DTOs.Students;
using JWT_P2.Models;
using JWT_P2.Repositories;
using JWT_P2.Repositories.Students;
using JWT_P2.SchoolDatabaseContext;
using JWT_P2.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace JWT_P2.Services.Students
{
    public class StudentsService : ICommonService<StudentsGetDTO, StudentsPostDTO, StudentsPutDTO>
    {
        private SchoolMessageDatabaseContext _schoolDabaseContext;
        private IMapper _studentsMappingProfile;
        private IStudentsRepo<JWT_P2.Models.Students> _studentsRepository;

        public StudentsService (SchoolMessageDatabaseContext schoolDabaseContext, IMapper studentsMappingProfile, [FromKeyedServices("studentsRepository")]IStudentsRepo<JWT_P2.Models.Students> studentsRepository)
        {
            _schoolDabaseContext = schoolDabaseContext;
            _studentsMappingProfile = studentsMappingProfile;
            _studentsRepository = studentsRepository;
        }

        public async Task<IEnumerable<StudentsGetDTO>> GetElements()
        {
            var students = await _studentsRepository.GetElementsFromRepository();
            var studentsDTO = students.Select(student => _studentsMappingProfile.Map<StudentsGetDTO>(student));
            return studentsDTO;
        }

        public async Task<StudentsGetDTO> GetElementById(Guid id)
        {
            var student = await _studentsRepository.GetElementFromRepositoryById(id);
            if (student == null) return null;

            var studentDTO = _studentsMappingProfile.Map<StudentsGetDTO>(student);
            return studentDTO;
        }


        public IEnumerable<StudentsGetDTO> GetElementByName(string name)
        {
            var student = _studentsRepository.GetElementByName(name);
            if (student == null) return null;

            var studentDTO = student.Select(student => _studentsMappingProfile.Map<StudentsGetDTO>(student)).ToList();
            return studentDTO;
        }


        public async Task<StudentsGetDTO> PostElement(StudentsPostDTO tPostDTO)
        {
            var student = _studentsMappingProfile.Map<JWT_P2.Models.Students>(tPostDTO);

            await _studentsRepository.AddElementFromRepository(student);
            await _studentsRepository.Save();

            var studentDTO = _studentsMappingProfile.Map<StudentsGetDTO>(student);

            return studentDTO;
        }


        public async Task<StudentsGetDTO> PutElement(StudentsPutDTO tPutDTO)
        {
            var student = await _schoolDabaseContext.Students.FindAsync(tPutDTO.Id);
            if (student == null) return null;

            student = _studentsMappingProfile.Map<StudentsPutDTO, JWT_P2.Models.Students>(tPutDTO, student);

            _studentsRepository.UdpateElementFromRepository(student);
            await _studentsRepository.Save();

            var studentDTO = _studentsMappingProfile.Map<StudentsGetDTO>(student);

            return studentDTO;
        }

        public async Task<StudentsGetDTO> DeleteElement(Guid id)
        {
            var student = await _schoolDabaseContext.Students.FindAsync(id);
            if (student == null) return null;

            _studentsRepository.DeleteElementFromRepository(student);
            await _studentsRepository.Save();

            var studentDTO = _studentsMappingProfile.Map<StudentsGetDTO>(student);
            return studentDTO;
        }
    }
}
