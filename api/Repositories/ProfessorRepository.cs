using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;

namespace api.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfessorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Professor GetProfessorById(int id)
        {
            return _context.Professors
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Professor> GetAllProfessors()
        {
            return _context.Professors
                .Include(p => p.Reviews)
                .ToList();
        }
        
        public void AddProfessor(Professor professor)
        {
            _context.Professors.Add(professor);
            _context.SaveChanges();
        }

        public void UpdateProfessor(Professor professor)
        {
            _context.Professors.Update(professor);
            _context.SaveChanges();
        }

        public void DeleteProfessor(int id)
        {
            var professor = GetProfessorById(id);
            if (professor != null)
            {
                _context.Professors.Remove(professor);
                _context.SaveChanges();
            }
        }
    }

    public interface IProfessorRepository
    {
        Professor GetProfessorById(int id);
        IEnumerable<Professor> GetAllProfessors();
        void AddProfessor(Professor professor);
        void UpdateProfessor(Professor professor);
        void DeleteProfessor(int id);
    }
}