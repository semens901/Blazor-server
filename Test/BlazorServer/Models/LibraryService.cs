using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models;

    public class LibraryService : ILibraryService
    {
        private BlazorServerContext _context;
        public LibraryService(BlazorServerContext context)
        {
            _context = context;
        }
        

        public void DeleteProposal(int Id)
        {
            try
            {
                Proposal ord = _context.Proposals.Find(Id);
                _context.Proposals.Remove(ord);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Proposal> GetProposals()
        {
            try
            {
                return _context.Proposals.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void InsertProposal(Proposal book)
        {
            try
            {
                _context.Proposals.Add(book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Proposal SingleProposal(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProposal(int Id, Proposal book)
        {
            try
            {
                var local = _context.Set<Proposal>().Local.FirstOrDefault(entry => entry.Id.Equals(book.Id));
                // check if local is not null
                if (local != null)
                {
                    // detach
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Entry(book).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

    }



