using JWT_P2.DTOs.Students;
using Microsoft.AspNetCore.Mvc;

namespace JWT_P2.Services.Common
{
    public interface ICommonService <TGetDTO, TPostDTO, TPutDTO>
    {
        Task<IEnumerable<TGetDTO>> GetElements();
        Task<TGetDTO> GetElementById(Guid id);
        IEnumerable<TGetDTO> GetElementByName(string name);
        Task<TGetDTO> PostElement(TPostDTO tPostDTO);
        Task<TGetDTO> PutElement(TPutDTO tPutDTO);
        Task<TGetDTO> DeleteElement(Guid id);
    }
}
