using api.Mappers;
using api.Repositories;
using api.Dto;

namespace api.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _repository;

        public ProfessorService(IProfessorRepository repository)
        {
            _repository = repository;
        }

        public ProfessorDto GetProfessorById(int id)
        {
            return ProfessorMappers.ToDto(_repository.GetProfessorById(id));
        }

        public IEnumerable<ProfessorDto> GetAllProfessors()
        {
            
            return ProfessorMappers.ToListDto(_repository.GetAllProfessors());
        }

        public void AddProfessor(ProfessorDto professor)
        {
            _repository.AddProfessor(ProfessorMappers.ToModel(professor));
        }

        public void UpdateProfessor(ProfessorDto professor)
        {
            _repository.UpdateProfessor(ProfessorMappers.ToModel(professor));
        }

        public void DeleteProfessor(int id)
        {
            // todo try verificat bla bla 
            _repository.DeleteProfessor(id);
        }
    }

    public interface IProfessorService
    {
        ProfessorDto GetProfessorById(int id);
        IEnumerable<ProfessorDto> GetAllProfessors();
        void AddProfessor(ProfessorDto professor);
        void UpdateProfessor(ProfessorDto professor);
        void DeleteProfessor(int id);
    }
}