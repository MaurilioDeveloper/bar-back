using AutoMapper;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.Configuration.Context;
using PortalDeParceiros.Infrastructure.IRepository;

namespace PortalDeParceiros.Infrastructure.Repository
{
    public class ProposalRepository : Repository<Proposal, long>, IProposalRepository
    {
        private readonly IMapper _mapper;
        private readonly PortalParceiroDbContext _context;
        public ProposalRepository(IMapper mapper, PortalParceiroDbContext context):base(context)
        {
            _mapper = mapper;
            _context = context;
        }
        public int InsertProposal(ProposalDto ProposalDto)
        {
            throw new System.NotImplementedException();
        }
    }
}