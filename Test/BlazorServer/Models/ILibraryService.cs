using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BlazorServer.Models;

    public interface ILibraryService
    {
        IEnumerable<Proposal> GetProposals();
        void InsertProposal(Proposal employee);
        void UpdateProposal(int Id, Proposal employee);
        Proposal SingleProposal(int Id);
        void DeleteProposal(int Id);
    }


