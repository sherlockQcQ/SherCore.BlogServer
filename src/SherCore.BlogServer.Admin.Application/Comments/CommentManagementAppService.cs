using Microsoft.AspNetCore.Authorization;
using SherCore.BlogServer.Comments;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace SherCore.BlogServer.Admin.Comments
{
    [Authorize()]
    [RemoteService(IsEnabled = false)]
    public class CommentManagementAppService : AdminAppService, ICommentManagementAppService
    {
        private readonly IRepository<Comment, Guid> _repository;

        public CommentManagementAppService(
            IRepository<Comment, Guid> repository)
        {
            _repository = repository;
        }

        public Task<CommentDto> CreateAsync(CreateCommentDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<CommentDto>> GetListAsync(CommentQueryOptionDto input)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDto> UpdateAsync(Guid id, UpdateCommentDto input)
        {
            throw new NotImplementedException();
        }
    }
}