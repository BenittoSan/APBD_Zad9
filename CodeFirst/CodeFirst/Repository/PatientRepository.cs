using CodeFirst.Context;
using CodeFirst.Exceptions;
using CodeFirst.Interfaces;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly Apbd9Context  _dbContext;

    public PatientRepository(Apbd9Context dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Patient?> GetPatient(int idPatient)
    {
        try
        {
            var patient = await _dbContext.Patients.Where(p => p.IdPatient == idPatient).FirstOrDefaultAsync();
            
            return patient;

        }
        catch (ArgumentNullException e)
        {
            return null;
        }
    }

    public async Task<Patient> CreatePatient(Patient patient)
    {
        try
        {
            var newPatien = patient;
            await _dbContext.Patients.AddAsync(newPatien);
           await _dbContext.SaveChangesAsync();
           return newPatien;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}