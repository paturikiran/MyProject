using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocAsmAssignmentsRepository : IDocAsmAssignmentsRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_ASM_ASSIGNMENTS> GetAll()
        {
            return _context.DOCUS_ASM_ASSIGNMENTS.AsQueryable();
        }

        //public IEnumerable<DOCUS_ASM_ASSIGNMENTS> Get(int id)
        //{
        //    return _context.DOCUS_ASM_ASSIGNMENTS.Where(docusAsmAssignments => docusAsmAssignments.ACCOUNT_NUMBER == id);
        //}

        public IEnumerable<DOCUS_ASM_ASSIGNMENTS> Get(int id)
        {
            if (_context.DOCUS_ASM_ASSIGNMENTS != null)
                return _context.DOCUS_ASM_ASSIGNMENTS.Where(reqId => reqId.ACCOUNT_NUMBER == id);
            return null;
        }

        public int Insert(DOCUS_ASM_ASSIGNMENTS assignmentRequest)
        {
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                _context.DOCUS_ASM_ASSIGNMENTS.Add(assignmentRequest);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            //_context.DOCUS_ASM_ASSIGNMENTS.Add(assignmentRequest);
           // _context.SaveChanges();
           // if (assignmentRequest != null)
           
               //     DateTime.Now, assignmentRequest.CREATED_BY, assignmentRequest.UPDATED_BY);
            return 0;
        }

        public void Update(DOCUS_ASM_ASSIGNMENTS assignmentRequest)
        {
            try
            {
                _context.Entry(assignmentRequest).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                
            }



        }


        public DOCUS_ASM_GET_GTA_FIELDS_Result GetGTA(int id)
        {
            return _context.DOCUS_ASM_GET_GTA_FIELDS(id).FirstOrDefault();
        }
    }
}