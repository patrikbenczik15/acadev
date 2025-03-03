using api.Dto;
using api.Models;

namespace api.Mappers
{
    public static class ProfessorMappers
    {
        public static ProfessorDto ToDto(this Professor professorModel)
        {
            return new ProfessorDto
            {
                Id = professorModel.Id,
                FirstName = professorModel.FirstName,
                LastName = professorModel.LastName,
                University = professorModel.University,
                Department = professorModel.Department,
               // Reviews = professorModel.Reviews.Select(r => r.ToDto()).ToList()
            };
        }

        public static Professor ToModel(this ProfessorDto professorDto)
        {
            return new Professor
            {
                Id = professorDto.Id,
                FirstName = professorDto.FirstName,
                LastName = professorDto.LastName,
                University = professorDto.University,
                Department = professorDto.Department,
               // Reviews = professorDto.Reviews.Select(r => r.ToModel()).ToList()
            };
        }
        
        public static List<ProfessorDto> ToListDto(IEnumerable<Professor> professors)
        {
            if (professors == null)
                return null;
            
            List<ProfessorDto> professorDtos = new List<ProfessorDto>();
            for (int i = 0; i < professors.Count(); i++)
            {
                professorDtos.Add(ToDto(professors.ElementAt(i)));
            }
            return professorDtos;
        }
    }
}