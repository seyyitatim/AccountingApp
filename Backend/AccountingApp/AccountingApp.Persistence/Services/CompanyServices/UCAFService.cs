using AccountingApp.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using AccountingApp.Application.Repositories;
using AccountingApp.Application.Repositories.UCAFRepositories;
using AccountingApp.Application.Services;
using AccountingApp.Application.Services.CompanyServices;
using AccountingApp.Domain.CompanyEntities;
using AccountingApp.Persistence.Contexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Persistence.Services.CompanyServices
{
    public class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _commandRepository;
        private readonly IContextService _contextService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context = null;
        public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUcafAsync(CreateUCAFCommandRequest request)
        {
            _commandRepository.SetDbContextInstance(GetContext(request.CompanyId));
            _unitOfWork.SetDbContextInstance(_context);

            var entity = _mapper.Map<UniformChartOfAccount>(request);
            entity.Id = Guid.NewGuid().ToString();

            await _commandRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        private CompanyDbContext GetContext(string companyId)
        {
            return _context ??= (CompanyDbContext)_contextService.CreateDbContextInsatance(companyId);
        }
    }
}
