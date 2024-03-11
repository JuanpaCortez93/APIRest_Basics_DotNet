using AutoMapper;
using JWT_P2.DTOs.Parents;
using JWT_P2.MappingProfiles;
using JWT_P2.Repositories;
using JWT_P2.Repositories.Parents;
using JWT_P2.Services.Common;

namespace JWT_P2.Services.Parents
{
    public class ParentsService : ICommonService<ParentsGetDTO, ParentsPostDTO, ParentsPutDTO>
    {

        private IParentsRepo _parentsRepository;
        private IMapper _parentsMappingProfile;

        public ParentsService([FromKeyedServices("parentsRepository")]IParentsRepo parentsRepository, IMapper parentsMappingProfile)
        {
            _parentsRepository = parentsRepository;
            _parentsMappingProfile = parentsMappingProfile;
        }

        public async Task<IEnumerable<ParentsGetDTO>> GetElements()
        {

            var parents = await _parentsRepository.GetElementsFromRepository();
            var parentsDTO = parents.Select(parent => _parentsMappingProfile.Map<ParentsGetDTO>(parent));
            return parentsDTO;
        }

        public async Task<ParentsGetDTO> GetElementById(Guid id)
        {
            var parent = await _parentsRepository.GetElementFromRepositoryById(id);
            if (parent == null) return null;
            var parentDTO = _parentsMappingProfile.Map<ParentsGetDTO>(parent);
            return parentDTO;
        }

        public async Task<ParentsGetDTO> PostElement(ParentsPostDTO tPostDTO)
        {
            var parent = _parentsMappingProfile.Map<JWT_P2.Models.Parents>(tPostDTO);
            await _parentsRepository.AddElementFromRepository(parent);
            await _parentsRepository.Save();

            var parentDTO = _parentsMappingProfile.Map<ParentsGetDTO>(parent);
            return parentDTO;
        }

        public async Task<ParentsGetDTO> PutElement(ParentsPutDTO tPutDTO)
        {
            var parent = await _parentsRepository.GetElementFromRepositoryById(tPutDTO.Id);
            if (parent == null) return null;

            parent = _parentsMappingProfile.Map<ParentsPutDTO, JWT_P2.Models.Parents>(tPutDTO, parent);

            _parentsRepository.UdpateElementFromRepository(parent);
            await _parentsRepository.Save();

            return _parentsMappingProfile.Map<ParentsGetDTO>(parent);

        }

        public async Task<ParentsGetDTO> DeleteElement(Guid id)
        {
            var parent = await _parentsRepository.GetElementFromRepositoryById(id);
            if (parent == null) return null;

            _parentsRepository.DeleteElementFromRepository(parent);
            await _parentsRepository.Save();

            return _parentsMappingProfile.Map<ParentsGetDTO>(parent);

        }

        public IEnumerable<ParentsGetDTO> GetElementByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
