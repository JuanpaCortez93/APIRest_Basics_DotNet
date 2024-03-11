using AutoMapper;
using JWT_P2.DTOs.ParentDetails;
using JWT_P2.Models;
using JWT_P2.Repositories;
using JWT_P2.Repositories.ParentDetailsRepo;

namespace JWT_P2.Services.ParentDetailsServ
{
    public class ParentDetailsService : IParentDetailsService<ParentDetailsGetDTO, ParentDetailsPostDTO, ParentDetailsPutDTO>
    {

        private IParentDetailsRepository _parentDetailsRepository;
        private IMapper _parentDetailsMappingProfile;

        public ParentDetailsService([FromKeyedServices("parentDetailsRepository")] IParentDetailsRepository parentDetailsRepository, IMapper parentDetailsMappingProfile)
        {
            _parentDetailsRepository = parentDetailsRepository;
            _parentDetailsMappingProfile = parentDetailsMappingProfile;
        }


        public async Task<IEnumerable<ParentDetailsGetDTO>> GetParentDetails()
        {
            var parentDetails = await _parentDetailsRepository.GetAllParentDetails();
            var parentDetailsDTO = parentDetails.Select(parentDetails => _parentDetailsMappingProfile.Map<ParentDetailsGetDTO>(parentDetails));
            return parentDetailsDTO;
        }

        public async Task<ParentDetailsGetDTO> GetParentDetailsById(Guid id)
        {
            var parentDetail = await _parentDetailsRepository.GetParentDetailsById(id);
            if (parentDetail == null) return null;
            var parentDetailDTO = _parentDetailsMappingProfile.Map<ParentDetailsGetDTO>(parentDetail);
            return parentDetailDTO;
        }

        public async Task<IEnumerable<ParentDetailsGetDTO>> GetParentDetailsByParentId(Guid id)
        {
            var parentDetails = await _parentDetailsRepository.GetParentDetailsByParentId(id);
            if (parentDetails == null) return null;
            var parentDetailsDTO = parentDetails.Select(parentDetails => _parentDetailsMappingProfile.Map<ParentDetailsGetDTO>(parentDetails));
            return parentDetailsDTO;
        }

        public async Task<IEnumerable<ParentDetailsGetDTO>> GetParentDetailsByStudentId(Guid id)
        {
            var parentDetails = await _parentDetailsRepository.GetParentDetailsByStudentId(id);
            if (parentDetails == null) return null;
            var parentDetailsDTO = parentDetails.Select(parentDetails => _parentDetailsMappingProfile.Map<ParentDetailsGetDTO>(parentDetails));
            return parentDetailsDTO;
        }


        public async Task<ParentDetailsGetDTO> AddParentDetails(ParentDetailsPostDTO t)
        {
            var parentDetail = _parentDetailsMappingProfile.Map<ParentDetails>(t);

            await _parentDetailsRepository.AddParentDetails(parentDetail);
            await _parentDetailsRepository.SaveChanges();

            var parentDetailDTO = _parentDetailsMappingProfile.Map<ParentDetailsGetDTO>(parentDetail);
            return parentDetailDTO;
        }

        public async Task<ParentDetailsGetDTO> UpdateParentDetails(ParentDetailsPutDTO t)
        {
            var parentDetail = await _parentDetailsRepository.GetParentDetailsById(t.Id);
            if (parentDetail == null) return null;

            parentDetail = _parentDetailsMappingProfile.Map<ParentDetailsPutDTO,ParentDetails>(t,parentDetail);

            _parentDetailsRepository.UpdateParentDetails(parentDetail);
            await _parentDetailsRepository.SaveChanges();

            var parentDetailDTO = _parentDetailsMappingProfile.Map<ParentDetailsGetDTO>(parentDetail);
            return parentDetailDTO;
        }

        public async Task<ParentDetailsGetDTO> DeleteParentDetails(Guid id)
        {
            var parentDetail = await _parentDetailsRepository.GetParentDetailsById(id);
            if (parentDetail == null) return null;

            _parentDetailsRepository.DeleteParentDetails(parentDetail);
            await _parentDetailsRepository.SaveChanges();

            var parentDetailDTO = _parentDetailsMappingProfile.Map<ParentDetailsGetDTO>(parentDetail);
            return parentDetailDTO;
        }

    }
}
