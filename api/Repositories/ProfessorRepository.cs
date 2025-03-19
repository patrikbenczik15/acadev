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
            // Obține entitatea direct din baza de date, nu din cache-ul contextului
            var existingProfessor = _context.Professors
                .AsNoTracking()  // Important: Previne tracking-ul entității
                .FirstOrDefault(p => p.Id == professor.Id);
        
            if (existingProfessor == null)
            {
                throw new KeyNotFoundException($"Professor with ID {professor.Id} not found");
            }
    
            // Detașăm orice entitate existentă cu același ID care ar putea fi urmărită
            var local = _context.Set<Professor>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(professor.Id));
    
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
    
            // Atașăm entitatea nouă și o marcăm ca modificată
            _context.Entry(professor).State = EntityState.Modified;
    
            // Salvăm modificările
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